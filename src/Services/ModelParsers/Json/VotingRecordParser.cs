using System.Text.Json;
using DataModel;
using DataModel.Constants;
using Services.Interfaces.Json;
using VoteRepository;

namespace Services.ModelParsers.Json;

public class VotingRecordParser : IJsonModelParser
{
    public async Task Parse(Stream data, IVoteRepository voteRepository)
    {
        var record =
            await JsonSerializer.DeserializeAsync<JsonVotingRecord>(data, Common.JsonSerializerOptions);
        if (record is null) return;

        await voteRepository.AddTableVersion(CollectionNames.SessionType, record.Version);
        await voteRepository.AddTableVersion(CollectionNames.Session, record.Version);
        await voteRepository.AddTableVersion(CollectionNames.Original, record.Version);
        await voteRepository.AddTableVersion(CollectionNames.Card, record.Version);
        await voteRepository.AddTableVersion(CollectionNames.CardOutstackCondition, record.Version);
        await voteRepository.AddTableVersion(CollectionNames.CardContest, record.Version);
        await voteRepository.AddTableVersion(CollectionNames.CardContestOutstackCondition, record.Version);
        await voteRepository.AddTableVersion(CollectionNames.Mark, record.Version);
        await voteRepository.AddTableVersion(CollectionNames.MarkOutstackCondition, record.Version);

        var electionId = await voteRepository.FindElection(record.ElectionId);
        foreach (var jsonSession in record.Sessions)
        {
            var sessionTypeId = await voteRepository.FindOrAddSessionType(jsonSession.SessionType);
            var session = JsonSessionToModel(jsonSession, electionId, sessionTypeId);
            var sessionId = await voteRepository.AddSession(session);

            var original = JsonOriginalToModel(jsonSession.Original, sessionId);
            var originalId = await voteRepository.AddOriginal(original);

            foreach (var jsonCard in jsonSession.Original.Cards)
            {
                var card = JsonCardToModel(jsonCard, originalId);
                var cardId = await voteRepository.AddCard(card);

                foreach (var outstackConditionId in jsonCard.OutstackConditionIds)
                    await voteRepository.AddCardOutstackCondition(cardId, outstackConditionId);

                foreach (var jsonCardContest in jsonCard.Contests)
                {
                    var cardContest = JsonCardContestToModel(jsonCardContest, cardId);
                    var cardContestId = await voteRepository.AddCardContest(cardContest);

                    foreach (var outstackConditionId in jsonCardContest.OutstackConditionIds)
                        await voteRepository.AddCardContestOutstackCondition(cardContestId, outstackConditionId);

                    foreach (var jsonMark in jsonCardContest.Marks)
                    {
                        var mark = JsonMarkToModel(jsonMark, cardContestId);
                        var markId = await voteRepository.AddMark(mark);

                        foreach (var outstackConditionId in jsonMark.OutstackConditionIds)
                            await voteRepository.AddMarkOutstackCondition(markId, outstackConditionId);
                    }
                }
            }
        }
    }

    private static Session JsonSessionToModel(JsonSession jsonSession, int electionEventId, int sessionTypeId)
    {
        return new Session
        {
            RecordId = jsonSession.RecordId,
            ElectionEventId = electionEventId,
            TabulatorId = jsonSession.TabulatorId,
            BatchId = jsonSession.BatchId,
            CountingGroupId = jsonSession.CountingGroupId,
            ImageMask = jsonSession.ImageMask,
            SessionTypeId = sessionTypeId,
            VotingSessionIdentifier = jsonSession.VotingSessionIdentifier,
            UniqueVotingIdentifier = jsonSession.UniqueVotingIdentifier
        };
    }

    private static Original JsonOriginalToModel(JsonOriginal jsonOriginal, int sessionId)
    {
        return new Original
        {
            PrecinctPortionId = jsonOriginal.PrecinctPortionId,
            BallotTypeId = jsonOriginal.BallotTypeId,
            IsCurrent = jsonOriginal.IsCurrent,
            SessionId = sessionId
        };
    }

    private static Card JsonCardToModel(JsonCard jsonCard, int originalId)
    {
        return new Card
        {
            CardId = jsonCard.Id,
            KeyInId = jsonCard.KeyInId,
            PaperIndex = jsonCard.PaperIndex,
            OriginalId = originalId
        };
    }

    private static CardContest JsonCardContestToModel(JsonCardContest jsonCardContest, int cardId)
    {
        return new CardContest
        {
            ManifestationId = jsonCardContest.ManifestationId,
            CardId = cardId,
            ContestId = jsonCardContest.Id,
            Undervotes = jsonCardContest.Undervotes,
            Overvotes = jsonCardContest.Overvotes
        };
    }

    private static Mark JsonMarkToModel(JsonMark jsonMark, int cardContestId)
    {
        return new Mark
        {
            CandidateId = jsonMark.CandidateId,
            ManifestationId = jsonMark.ManifestationId,
            PartyId = jsonMark.PartyId,
            Rank = jsonMark.Rank,
            MarkDensity = jsonMark.MarkDensity,
            IsAmbiguous = jsonMark.IsAmbiguous,
            IsVote = jsonMark.IsVote,
            CardContestId = cardContestId
        };
    }

    private class JsonVotingRecord
    {
        public required string Version { get; set; }
        public required string ElectionId { get; set; }
        public required ICollection<JsonSession> Sessions { get; set; }
    }

    private class JsonSession
    {
        public required int TabulatorId { get; set; }
        public required int BatchId { get; set; }
        public required int RecordId { get; set; }
        public required int CountingGroupId { get; set; }
        public required string ImageMask { get; set; }
        public required string SessionType { get; set; }
        public required string VotingSessionIdentifier { get; set; }
        public required string UniqueVotingIdentifier { get; set; }
        public required JsonOriginal Original { get; set; }
    }

    private class JsonOriginal
    {
        public required int PrecinctPortionId { get; set; }
        public required int BallotTypeId { get; set; }
        public required bool IsCurrent { get; set; }
        public required ICollection<JsonCard> Cards { get; set; }
    }

    private class JsonCard
    {
        public required int Id { get; set; }
        public required int KeyInId { get; set; }
        public required int PaperIndex { get; set; }
        public required ICollection<JsonCardContest> Contests { get; set; }
        public required int[] OutstackConditionIds { get; set; }
    }

    private class JsonCardContest
    {
        public required int Id { get; set; }
        public required int ManifestationId { get; set; }
        public required int Undervotes { get; set; }
        public required int Overvotes { get; set; }
        public required int[] OutstackConditionIds { get; set; }
        public required ICollection<JsonMark> Marks { get; set; }
    }

    private class JsonMark
    {
        public required int CandidateId { get; set; }
        public required int ManifestationId { get; set; }
        public required int PartyId { get; set; }
        public required int Rank { get; set; }
        public required int MarkDensity { get; set; }
        public required bool IsAmbiguous { get; set; }
        public required bool IsVote { get; set; }
        public required int[] OutstackConditionIds { get; set; }
    }
}
