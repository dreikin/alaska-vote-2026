using System.Text.Json;
using DataModel;
using DataModel.Constants;
using Repository;
using Services.Interfaces.Json;

namespace Services.ModelParsers.Json;

public class DistrictPrecinctPortionManifestParser : IJsonModelParser
{
    public async Task Parse(Stream data, IVoteRepository voteRepository)
    {
        var manifest =
            await JsonSerializer.DeserializeAsync<Manifest<DistrictPrecinctPortion>>(data,
                Common.JsonSerializerOptions);
        if (manifest is null) return;
        await voteRepository.FindOrAddCollectionVersion(CollectionNames.DistrictPrecinctPortion, manifest.Version);
        foreach (var item in manifest.List) await voteRepository.AddDistrictPrecinctPortion(item);
    }
}
