using VoteRepository;

namespace Services.Interfaces;

public interface IFileParser
{
    Task Parse(string path, IVoteRepository voteRepository);
}
