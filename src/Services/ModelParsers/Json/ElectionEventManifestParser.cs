using System.Text.Json;
using DataModel;
using DataModel.Constants;
using Services.Interfaces.Json;
using VoteRepository;

namespace Services.ModelParsers.Json;

public class ElectionEventManifestParser : IJsonModelParser
{
    public async Task Parse(Stream data, IVoteRepository voteRepository)
    {
        var manifest =
            await JsonSerializer.DeserializeAsync<Manifest<JsonElectionEvent>>(data, Common.JsonSerializerOptions);
        if (manifest is null) return;

        await voteRepository.AddTableVersion(CollectionNames.Jurisdiction, manifest.Version);
        await voteRepository.AddTableVersion(CollectionNames.ElectionEvent, manifest.Version);

        foreach (var item in manifest.List)
        {
            var jurisdictionId = await voteRepository.FindOrAddJurisdiction(item.Jurisdiction);
            await voteRepository.AddElectionEvent(ConvertJsonToModel(item, jurisdictionId));
        }
    }

    private static ElectionEvent ConvertJsonToModel(JsonElectionEvent jsonElectionEvent, int jurisdictionId)
    {
        return new ElectionEvent
        {
            Id = jsonElectionEvent.Id,
            Description = jsonElectionEvent.Description,
            ExternalId = jsonElectionEvent.ExternalId,
            JurisdictionId = jurisdictionId,
            ElectionDate = DateOnly.ParseExact(jsonElectionEvent.ElectionDate, "yyyyMMdd"),
            ElectionSignature = [.. jsonElectionEvent.ElectionSignature.Select(Convert.ToByte)]
        };
    }

    private class JsonElectionEvent
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required string ExternalId { get; set; }
        public required string Jurisdiction { get; set; }
        public required string ElectionDate { get; set; }
        public required int[] ElectionSignature { get; set; }
    }
}
