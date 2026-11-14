using DataModel;

namespace VoteRepository;

public interface IVoteRepository
{
    Task AddTableVersion(string table, string version);
    Task AddBallotType(BallotType item);
}
