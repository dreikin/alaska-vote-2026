using System.Text.Json;
using DataModel;
using DataModel.Constants;
using Services.Interfaces.Json;
using VoteRepository;

namespace Services.ModelParsers.Json;

public class CandidateManifestParser : IJsonModelParser
{
    public async Task Parse(Stream data, IVoteRepository voteRepository)
    {
        var manifest =
            await JsonSerializer.DeserializeAsync<Manifest<JsonCandidate>>(data, Common.JsonSerializerOptions);
        if (manifest is null) return;

        await voteRepository.AddTableVersion(CollectionNames.Candidate, manifest.Version);
        await voteRepository.AddTableVersion(CollectionNames.CandidateType, manifest.Version);
        await voteRepository.AddTableVersion(CollectionNames.CandidateAffiliation, manifest.Version);

        foreach (var item in manifest.List)
        {
            var candidateType = await voteRepository.FindOrAddCandidateType(item.Type);
            var candidateId = await voteRepository.AddCandidate(ConvertJsonToModel(item, candidateType));
            foreach (var affiliationId in item.Affiliations)
                await voteRepository.AddCandidateAffiliation(candidateId, affiliationId);
        }
    }

    private Candidate ConvertJsonToModel(JsonCandidate jsonCandidate, int candidateTypeId)
    {
        return new Candidate
        {
            Id = jsonCandidate.Id,
            Description = jsonCandidate.Description,
            ExternalId = jsonCandidate.ExternalId,
            ContestId = jsonCandidate.ContestId,
            CandidateTypeId = candidateTypeId,
            Disabled = jsonCandidate.Disabled != 0
        };
    }

    private class JsonCandidate
    {
        public required int Id { get; set; }
        public required string Description { get; set; }
        public required string ExternalId { get; set; }
        public required int ContestId { get; set; }
        public required string Type { get; set; }
        public required int Disabled { get; set; }
        public required int[] Affiliations { get; set; }
    }
}
