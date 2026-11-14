using Services.Interfaces;
using VoteRepository;

namespace Services.FileParsers.Json;

public class DistrictPrecinctPortionManifestParser : IFileParser
{
    public async Task Parse(string path, IVoteRepository voteRepository)
    {
        throw new NotImplementedException();
    }
}
