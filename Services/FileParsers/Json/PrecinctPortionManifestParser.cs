using Services.Interfaces;
using VoteRepository;

namespace Services.FileParsers.Json;

public class PrecinctPortionManifestParser : IFileParser
{
    public async Task Parse(string path, IVoteRepository voteRepository)
    {
        throw new NotImplementedException();
    }
}
