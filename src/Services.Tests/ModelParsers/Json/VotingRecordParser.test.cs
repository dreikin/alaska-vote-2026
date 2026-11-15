using System.Text;
using DataModel;
using DataModel.Constants;
using Repository;

namespace Services.Tests.ModelParsers.Json;

public class VotingRecordParser
{
    private const string SingleItemList = """
                                          {
                                              "Version": "5.17.18.1",
                                              "ElectionId": "2026 General Election",
                                              "Sessions": [
                                                  {
                                                      "TabulatorId": 92904,
                                                      "BatchId": 0,
                                                      "RecordId": 98647,
                                                      "CountingGroupId": 3,
                                                      "ImageMask": "D:\\NAS\\2026 General Election\\Results\\Tabulator92904\\Batch000\\Images\\92904_00000_098647_*.*",
                                                      "SessionType": "ScannedVote",
                                                      "VotingSessionIdentifier": "",
                                                      "UniqueVotingIdentifier": "",
                                                      "Original": {
                                                          "PrecinctPortionId": 463,
                                                          "BallotTypeId": 24,
                                                          "IsCurrent": true,
                                                          "Cards": [
                                                              {
                                                                  "Id": 334,
                                                                  "KeyInId": 334,
                                                                  "PaperIndex": 0,
                                                                  "Contests": [
                                                                      {
                                                                          "Id": 6,
                                                                          "ManifestationId": 419,
                                                                          "Undervotes": 0,
                                                                          "Overvotes": 0,
                                                                          "OutstackConditionIds": [
                                                                              14
                                                                          ],
                                                                          "Marks": [
                                                                              {
                                                                                  "CandidateId": 525,
                                                                                  "ManifestationId": 2777,
                                                                                  "PartyId": 7,
                                                                                  "Rank": 1,
                                                                                  "MarkDensity": 98,
                                                                                  "IsAmbiguous": false,
                                                                                  "IsVote": true,
                                                                                  "OutstackConditionIds": [64, 29]
                                                                              },
                                                                          ]
                                                                      }
                                                                  ],
                                                                  "OutstackConditionIds": [3]
                                                              }
                                                          ]
                                                      }
                                                  },
                                              ]
                                          }
                                          """;

    private readonly Card _expectedCard = new()
    {
        CardId = 334,
        KeyInId = 334,
        PaperIndex = 0,
        OriginalId = 1
    };

    private readonly CardContest _expectedCardContest = new()
    {
        ManifestationId = 419,
        CardId = 123,
        ContestId = 6,
        Undervotes = 0,
        Overvotes = 0
    };

    private readonly CardContestOutstackCondition _expectedCardContestOutstackCondition = new()
    {
        CardContestId = 456,
        OutstackConditionId = 14
    };

    private readonly CardOutstackCondition _expectedCardOutstackCondition = new()
    {
        CardId = 123,
        OutstackConditionId = 3
    };

    private readonly Mark _expectedMark = new()
    {
        CandidateId = 525,
        ManifestationId = 2777,
        PartyId = 7,
        Rank = 1,
        MarkDensity = 98,
        IsAmbiguous = false,
        IsVote = true,
        CardContestId = 456
    };

    private readonly MarkOutstackCondition _expectedMarkOutstackCondition = new()
    {
        MarkId = 789,
        OutstackConditionId = 64
    };

    private readonly MarkOutstackCondition _expectedMarkOutstackCondition2 = new()
    {
        MarkId = 789,
        OutstackConditionId = 29
    };

    private readonly Original _expectedOriginal = new()
    {
        PrecinctPortionId = 463,
        BallotTypeId = 24,
        IsCurrent = true,
        SessionId = 99
    };

    private readonly Session _expectedSession = new()
    {
        RecordId = 98647,
        ElectionEventId = 1776,
        TabulatorId = 92904,
        BatchId = 0,
        CountingGroupId = 3,
        ImageMask = @"D:\NAS\2026 General Election\Results\Tabulator92904\Batch000\Images\92904_00000_098647_*.*",
        SessionTypeId = 2026,
        VotingSessionIdentifier = "",
        UniqueVotingIdentifier = ""
    };

    private IVoteRepositoryMock CreateMockVoteRepository()
    {
        var repository = IVoteRepository.Mock();
        repository.FindElection(Any()).ReturnsAsync(Task.FromResult(_expectedSession.ElectionEventId));
        repository.FindOrAddSessionType(Any()).ReturnsAsync(Task.FromResult(_expectedSession.SessionTypeId));
        repository.AddSession(Any()).ReturnsAsync(Task.FromResult(_expectedOriginal.SessionId));
        repository.AddOriginal(Any()).ReturnsAsync(Task.FromResult(_expectedCard.OriginalId));
        repository.AddCard(Any()).ReturnsAsync(Task.FromResult(_expectedCardContest.CardId));
        repository.AddCardContest(Any())
            .ReturnsAsync(Task.FromResult(_expectedMark.CardContestId));
        repository.AddMark(Any()).ReturnsAsync(Task.FromResult(_expectedMarkOutstackCondition.MarkId));

        return repository;
    }

    [Test]
    [Arguments(CollectionNames.SessionType)]
    [Arguments(CollectionNames.Session)]
    [Arguments(CollectionNames.Original)]
    [Arguments(CollectionNames.Card)]
    [Arguments(CollectionNames.CardOutstackCondition)]
    [Arguments(CollectionNames.CardContest)]
    [Arguments(CollectionNames.CardContestOutstackCondition)]
    [Arguments(CollectionNames.Mark)]
    [Arguments(CollectionNames.MarkOutstackCondition)]
    public async Task Parse_Adds_TableVersion(string collectionName)
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = CreateMockVoteRepository();
        var parser = new Services.ModelParsers.Json.VotingRecordParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddTableVersion(Any(), Any())).WasCalled(Times.Exactly(9));
        await Assert.That(repository.AddTableVersion(collectionName, "5.17.18.1")).WasCalled(Times.Once);
    }

    private static bool SessionsAreEqual(Session actual, Session expected)
    {
        return actual.ElectionEventId == expected.ElectionEventId
               && actual.TabulatorId == expected.TabulatorId
               && actual.BatchId == expected.BatchId
               && actual.RecordId == expected.RecordId
               && actual.CountingGroupId == expected.CountingGroupId
               && actual.ImageMask == expected.ImageMask
               && actual.SessionTypeId == expected.SessionTypeId
               && actual.VotingSessionIdentifier == expected.VotingSessionIdentifier
               && actual.UniqueVotingIdentifier == expected.UniqueVotingIdentifier;
    }

    [Test]
    public async Task Parse_Adds_Session()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = CreateMockVoteRepository();
        var parser = new Services.ModelParsers.Json.VotingRecordParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddSession(Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.AddSession(Is<Session>(actual =>
                SessionsAreEqual(actual, _expectedSession))))
            .WasCalled(Times.Once);
    }

    private static bool OriginalsAreEqual(Original actual, Original expected)
    {
        return actual.PrecinctPortionId == expected.PrecinctPortionId
               && actual.BallotTypeId == expected.BallotTypeId
               && actual.IsCurrent == expected.IsCurrent
               && actual.SessionId == expected.SessionId;
    }

    [Test]
    public async Task Parse_Adds_Original()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = CreateMockVoteRepository();
        var parser = new Services.ModelParsers.Json.VotingRecordParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddOriginal(Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.AddOriginal(Is<Original>(actual =>
                OriginalsAreEqual(actual, _expectedOriginal))))
            .WasCalled(Times.Once);
    }

    private static bool CardsAreEqual(Card actual, Card expected)
    {
        return actual.CardId == expected.CardId
               && actual.KeyInId == expected.KeyInId
               && actual.PaperIndex == expected.PaperIndex
               && actual.OriginalId == expected.OriginalId;
    }

    [Test]
    public async Task Parse_Adds_Card()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = CreateMockVoteRepository();
        var parser = new Services.ModelParsers.Json.VotingRecordParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddCard(Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.AddCard(Is<Card>(actual =>
                CardsAreEqual(actual, _expectedCard))))
            .WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_CardOutstackCondition()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = CreateMockVoteRepository();
        var parser = new Services.ModelParsers.Json.VotingRecordParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddCardOutstackCondition(Any(), Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.AddCardOutstackCondition(_expectedCardOutstackCondition.CardId,
                _expectedCardOutstackCondition.OutstackConditionId))
            .WasCalled(Times.Once);
    }

    private static bool CardContestsAreEqual(CardContest actual, CardContest expected)
    {
        return actual.ManifestationId == expected.ManifestationId
               && actual.CardId == expected.CardId
               && actual.ContestId == expected.ContestId
               && actual.Undervotes == expected.Undervotes
               && actual.Overvotes == expected.Overvotes;
    }

    [Test]
    public async Task Parse_Adds_CardContest()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = CreateMockVoteRepository();
        var parser = new Services.ModelParsers.Json.VotingRecordParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddCardContest(Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.AddCardContest(Is<CardContest>(actual =>
                CardContestsAreEqual(actual, _expectedCardContest))))
            .WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_CardContestOutstackCondition()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = CreateMockVoteRepository();
        var parser = new Services.ModelParsers.Json.VotingRecordParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddCardContestOutstackCondition(Any(), Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.AddCardContestOutstackCondition(_expectedCardContestOutstackCondition.CardContestId,
                _expectedCardContestOutstackCondition.OutstackConditionId))
            .WasCalled(Times.Once);
    }

    private static bool MarksAreEqual(Mark actual, Mark expected)
    {
        return actual.ManifestationId == expected.ManifestationId
               && actual.CardContestId == expected.CardContestId
               && actual.CandidateId == expected.CandidateId
               && actual.PartyId == expected.PartyId
               && actual.Rank == expected.Rank
               && actual.MarkDensity == expected.MarkDensity
               && actual.IsAmbiguous == expected.IsAmbiguous
               && actual.IsVote == expected.IsVote;
    }

    [Test]
    public async Task Parse_Adds_Marks()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = CreateMockVoteRepository();
        var parser = new Services.ModelParsers.Json.VotingRecordParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddMark(Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.AddMark(Is<Mark>(actual =>
                MarksAreEqual(actual, _expectedMark))))
            .WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_MarkOutstackCondition()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = CreateMockVoteRepository();
        var parser = new Services.ModelParsers.Json.VotingRecordParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddMarkOutstackCondition(Any(), Any())).WasCalled(Times.Exactly(2));
        await Assert
            .That(repository.AddMarkOutstackCondition(_expectedMarkOutstackCondition.MarkId,
                _expectedMarkOutstackCondition.OutstackConditionId))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddMarkOutstackCondition(_expectedMarkOutstackCondition2.MarkId,
                _expectedMarkOutstackCondition2.OutstackConditionId))
            .WasCalled(Times.Once);
    }
}
