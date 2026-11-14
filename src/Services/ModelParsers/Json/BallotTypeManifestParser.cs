using Services.Interfaces.Json;
using VoteRepository;

namespace Services.ModelParsers.Json;

public class BallotTypeManifestParser : IJsonModelParser
{
    public async Task Parse(Stream data, IVoteRepository voteRepository)
    {
        throw new NotImplementedException();
    }
}
