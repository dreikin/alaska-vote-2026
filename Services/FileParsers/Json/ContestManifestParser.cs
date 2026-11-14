using Services.Interfaces;
using VoteRepository;

namespace Services.FileParsers.Json;

public class ContestManifestParser : IFileParser
{
    public async Task Parse(string path, IVoteRepository voteRepository)
    {
        throw new NotImplementedException();
    }
}
