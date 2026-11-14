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
    Task<int> AddParty(Party item);
    Task<int> AddPrecinct(Precinct item);
    Task<int> AddPrecinctPortion(PrecinctPortion item);
    Task<int> FindOrAddTabulatorType(string itemType);
    Task<int> AddVotingLocation(int itemVotingLocationNumber, string itemVotingLocationName);
    Task<int> AddTabulator(Tabulator item);
    Task<int> AddDistrictPrecinctPortion(DistrictPrecinctPortion item);
    Task<int> FindOrAddContestType(string itemType);
    Task<int> AddContest(Contest convertJsonToModel);
    Task<int> SetConfiguration(Configuration configuration);
    Task<int> FindOrAddCandidateType(string itemType);
    Task<int> AddCandidate(Candidate convertJsonToModel);
    Task<int> AddCandidateAffiliation(int candidateId, int affiliationId);
    Task<int> AddBallotTypeContest(BallotTypeContest item);
}
