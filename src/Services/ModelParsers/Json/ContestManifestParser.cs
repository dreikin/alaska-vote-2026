using System.Text.Json;
using DataModel;
using DataModel.Constants;
using Repository;
using Services.Interfaces.Json;

namespace Services.ModelParsers.Json;

public class ContestManifestParser : IJsonModelParser
{
    public async Task Parse(Stream data, IVoteRepository voteRepository)
    {
        var manifest =
            await JsonSerializer.DeserializeAsync<Manifest<JsonContest>>(data, Common.JsonSerializerOptions);
        if (manifest is null) return;
        await voteRepository.FindOrAddCollectionVersion(CollectionNames.Contest, manifest.Version);
        await voteRepository.FindOrAddCollectionVersion(CollectionNames.ContestType, manifest.Version);
        foreach (var item in manifest.List)
        {
            var contestTypeId = await voteRepository.FindOrAddContestType(item.Type);
            await voteRepository.AddContest(ConvertJsonToModel(item, contestTypeId));
        }
    }

    private static Contest ConvertJsonToModel(JsonContest jsonContest, int typeId)
    {
        return new Contest
        {
            Id = jsonContest.Id,
            Description = jsonContest.Description,
            ExternalId = jsonContest.ExternalId,
            DistrictId = jsonContest.DistrictId,
            VoteFor = jsonContest.VoteFor,
            NumOfRanks = jsonContest.NumOfRanks,
            NumOfWriteins = jsonContest.NumOfWriteins,
            Disabled = jsonContest.Disabled != 0,
            ContestTypeId = typeId
        };
    }

    private class JsonContest
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required string ExternalId { get; set; }
        public int DistrictId { get; set; }
        public int VoteFor { get; set; }
        public int NumOfRanks { get; set; }
        public int NumOfWriteins { get; set; }
        public int Disabled { get; set; }
        public required string Type { get; set; }
    }
}
