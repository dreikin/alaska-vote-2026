using System.Text.Json;
using DataModel;
using DataModel.Constants;
using Services.Interfaces.Json;
using VoteRepository;

namespace Services.ModelParsers.Json;

public class BallotTypeManifestParser : IJsonModelParser
{
    public async Task Parse(Stream data, IVoteRepository voteRepository)
    {
        var manifest = await JsonSerializer.DeserializeAsync<Manifest<BallotType>>(data, Common.JsonSerializerOptions);
        if (manifest is null) return;
        await voteRepository.AddTableVersion(CollectionNames.BallotType, manifest.Version);
        foreach (var item in manifest.List) await voteRepository.AddBallotType(item);
    }
}
