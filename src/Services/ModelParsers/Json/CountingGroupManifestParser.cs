using System.Text.Json;
using DataModel;
using DataModel.Constants;
using Repository;
using Services.Interfaces.Json;

namespace Services.ModelParsers.Json;

public class CountingGroupManifestParser : IJsonModelParser
{
    public async Task Parse(Stream data, IVoteRepository voteRepository)
    {
        var manifest =
            await JsonSerializer.DeserializeAsync<Manifest<CountingGroup>>(data, Common.JsonSerializerOptions);
        if (manifest is null) return;
        await voteRepository.FindOrAddCollectionVersion(CollectionNames.CountingGroup, manifest.Version);
        foreach (var item in manifest.List) await voteRepository.AddCountingGroup(item);
    }
}
