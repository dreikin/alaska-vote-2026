using System.Text.Json;
using DataModel;
using Repository;
using Services.Interfaces.Json;

namespace Services.ModelParsers.Json;

public class ConfigurationParser : IJsonModelParser
{
    public async Task Parse(Stream data, IVoteRepository voteRepository)
    {
        var configuration =
            await JsonSerializer.DeserializeAsync<Configuration>(data, Common.JsonSerializerOptions);
        if (configuration is null) return;
        await voteRepository.SetConfiguration(configuration);
    }
}
