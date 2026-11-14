using DataModel;

namespace VoteRepository;

public interface IVoteRepository
{
    Task<int> AddTableVersion(string table, string version);
    Task<int> AddBallotType(BallotType item);
    Task<int> AddCountingGroup(CountingGroup item);
    Task<int> AddDistrictType(DistrictType item);
    Task<int> AddDistrict(District item);
    Task<int> FindOrAddJurisdiction(string description);
    Task<int> AddElectionEvent(ElectionEvent item);
    Task<int> AddOutstackCondition(OutstackCondition item);
}
