using System.Text.Json;
using DataModel;
using Services.Interfaces.Json;
using VoteRepository;

namespace Services.ModelParsers.Json;

public class BallotTypeManifestParser : IJsonModelParser
{
    private JsonSerializerOptions JsonSerializerOptions { get; } = new() { PropertyNameCaseInsensitive = true };

    public async Task Parse(Stream data, IVoteRepository voteRepository)
    {
        var manifest = await JsonSerializer.DeserializeAsync<Manifest<BallotType>>(data, JsonSerializerOptions);
        if (manifest is null) return;
        await voteRepository.AddTableVersion("BallotType", manifest.Version);
        foreach (var item in manifest.List) await voteRepository.AddBallotType(item);
    }
}
