using VoteRepository;

namespace Services.Interfaces;

public interface IModelParser
{
    Task Parse(Stream data, IVoteRepository voteRepository);
}
