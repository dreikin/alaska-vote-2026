using System.Text.Json;
using DataModel;
using DataModel.Constants;
using Services.Interfaces.Json;
using VoteRepository;

namespace Services.ModelParsers.Json;

public class TabulatorManifestParser : IJsonModelParser
{
    public async Task Parse(Stream data, IVoteRepository voteRepository)
    {
        var manifest =
            await JsonSerializer.DeserializeAsync<Manifest<JsonTabulator>>(data, Common.JsonSerializerOptions);
        if (manifest is null) return;

        await voteRepository.AddTableVersion(CollectionNames.Tabulator, manifest.Version);
        await voteRepository.AddTableVersion(CollectionNames.TabulatorType, manifest.Version);
        await voteRepository.AddTableVersion(CollectionNames.VotingLocation, manifest.Version);

        foreach (var item in manifest.List)
        {
            var tabulatorTypeId = await voteRepository.FindOrAddTabulatorType(item.Type);
            await voteRepository.AddVotingLocation(item.VotingLocationNumber, item.VotingLocationName);
            await voteRepository.AddTabulator(ConvertJsonToTabulator(item, tabulatorTypeId));
        }
    }

    private static Tabulator ConvertJsonToTabulator(JsonTabulator jsonTabulator, int tabulatorTypeId)
    {
        return new Tabulator
        {
            Id = jsonTabulator.Id,
            Description = jsonTabulator.Description,
            ExternalId = jsonTabulator.ExternalId,
            VotingLocationId = jsonTabulator.VotingLocationNumber,
            TabulatorTypeId = tabulatorTypeId,
            ThresholdMin = jsonTabulator.ThresholdMin,
            ThresholdMax = jsonTabulator.ThresholdMax,
            WriteThresholdMin = jsonTabulator.WriteThresholdMin,
            WriteThresholdMax = jsonTabulator.WriteThresholdMax
        };
    }

    private class JsonTabulator
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required string ExternalId { get; set; }
        public int VotingLocationNumber { get; set; }
        public required string VotingLocationName { get; set; }
        public required string Type { get; set; }
        public int ThresholdMin { get; set; }
        public int ThresholdMax { get; set; }
        public int WriteThresholdMin { get; set; }
        public int WriteThresholdMax { get; set; }
    }
}
