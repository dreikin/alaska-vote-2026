using Services.Interfaces;
using VoteRepository;

namespace Services.ModelParsers.Json;

public class ConfigurationParser : IModelParser
{
    public async Task Parse(Stream data, IVoteRepository voteRepository)
    {
        throw new NotImplementedException();
    }
}
