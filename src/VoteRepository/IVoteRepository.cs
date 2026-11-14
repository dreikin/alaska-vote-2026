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
    Task<int> FindElection(string recordElectionId);
    Task<int> FindOrAddSessionType(string jsonSessionSessionType);
    Task<int> AddSession(Session session);
    Task<int> AddOriginal(Original original);
    Task<int> AddCard(Card card);
    Task<int> AddCardOutstackCondition(int cardId, int outstackConditionId);
    Task<int> AddCardContest(CardContest cardContest);
    Task<int> AddCardContestOutstackCondition(int cardContestId, int outstackConditionId);
    Task<int> AddMark(Mark mark);
    Task<int> AddMarkOutstackCondition(int markId, int outstackConditionId);
}
