using DataModel;
using DB.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Repository.EntityFramework;

public class VoteRepository(VoteRepositoryContext context, bool repositoryOwnsContext = false)
    : IVoteRepository
{
    public async Task<int> FindOrAddCollectionVersion(string name, string version)
    {
        var id = await context.CollectionVersions
            .Where(t => t.Name == name && t.Version == version)
            .Select(t => t.Id)
            .SingleOrDefaultAsync();
        if (id > 0) return id;

        var collectionVersion = new CollectionVersion { Name = name, Version = version };
        await context.CollectionVersions.AddAsync(collectionVersion);
        await context.SaveChangesAsync();

        return collectionVersion.Id;
    }

    public async Task<int> FindOrAddBallotType(BallotType item)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddCountingGroup(CountingGroup item)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddDistrictType(DistrictType item)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddDistrict(District item)
    {
        throw new NotImplementedException();
    }

    public async Task<int> FindOrAddJurisdiction(string description)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddElectionEvent(ElectionEvent item)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddOutstackCondition(OutstackCondition item)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddParty(Party item)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddPrecinct(Precinct item)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddPrecinctPortion(PrecinctPortion item)
    {
        throw new NotImplementedException();
    }

    public async Task<int> FindOrAddTabulatorType(string itemType)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddVotingLocation(int itemVotingLocationNumber, string itemVotingLocationName)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddTabulator(Tabulator item)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddDistrictPrecinctPortion(DistrictPrecinctPortion item)
    {
        throw new NotImplementedException();
    }

    public async Task<int> FindOrAddContestType(string itemType)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddContest(Contest convertJsonToModel)
    {
        throw new NotImplementedException();
    }

    public async Task<int> SetConfiguration(Configuration configuration)
    {
        throw new NotImplementedException();
    }

    public async Task<int> FindOrAddCandidateType(string itemType)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddCandidate(Candidate convertJsonToModel)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddCandidateAffiliation(int candidateId, int affiliationId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddBallotTypeContest(BallotTypeContest item)
    {
        throw new NotImplementedException();
    }

    public async Task<int> FindElection(string recordElectionId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> FindOrAddSessionType(string jsonSessionSessionType)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddSession(Session session)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddOriginal(Original original)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddCard(Card card)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddCardOutstackCondition(int cardId, int outstackConditionId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddCardContest(CardContest cardContest)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddCardContestOutstackCondition(int cardContestId, int outstackConditionId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddMark(Mark mark)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddMarkOutstackCondition(int markId, int outstackConditionId)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        if (repositoryOwnsContext) context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        if (repositoryOwnsContext) await context.DisposeAsync();
    }
}
