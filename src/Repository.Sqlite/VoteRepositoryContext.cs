using DataModel;
using Microsoft.EntityFrameworkCore;

namespace Repository.Sqlite;

public class VoteRepositoryContext : DbContext
{
    public DbSet<BallotType> BallotTypes { get; set; }
    public DbSet<BallotTypeContest> BallotTypeContests { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<CandidateAffiliation> CandidateAffiliations { get; set; }
    public DbSet<CandidateType> CandidateTypes { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<CardContest> CardContests { get; set; }
    public DbSet<CardContestOutstackCondition> CardContestOutstackConditions { get; set; }
    public DbSet<CardOutstackCondition> CardOutstackConditions { get; set; }
    public DbSet<Configuration> Configurations { get; set; }
    public DbSet<Contest> Contests { get; set; }
    public DbSet<ContestFilter> ContestFilters { get; set; }
    public DbSet<ContestType> ContestTypes { get; set; }
    public DbSet<CountingGroup> CountingGroups { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<DistrictPrecinctPortion> DistrictPrecinctPortions { get; set; }
    public DbSet<DistrictType> DistrictTypes { get; set; }
    public DbSet<ElectionEvent> ElectionEvents { get; set; }
    public DbSet<Jurisdiction> Jurisdictions { get; set; }
    public DbSet<Mark> Marks { get; set; }
    public DbSet<MarkOutstackCondition> MarkOutstackConditions { get; set; }
    public DbSet<Original> Originals { get; set; }
    public DbSet<OutstackCondition> OutstackConditions { get; set; }
    public DbSet<Party> Parties { get; set; }
    public DbSet<Precinct> Precincts { get; set; }
    public DbSet<PrecinctPortion> PrecinctPortions { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<SessionType> SessionTypes { get; set; }
    public DbSet<TableVersion> TableVersions { get; set; }
    public DbSet<Tabulator> Tabulators { get; set; }
    public DbSet<TabulatorType> TabulatorTypes { get; set; }
    public DbSet<VotingLocation> VotingLocations { get; set; }
}
