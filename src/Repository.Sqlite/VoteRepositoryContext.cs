using DataModel;
using Microsoft.EntityFrameworkCore;

namespace Repository.Sqlite;

public class VoteRepositoryContext : DbContext
{
    public DbSet<BallotType> BallotTypes { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<CandidateType> CandidateTypes { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<CardContest> CardContests { get; set; }
    public DbSet<Configuration> Configurations { get; set; }
    public DbSet<Contest> Contests { get; set; }
    public DbSet<ContestFilter> ContestFilters { get; set; }
    public DbSet<ContestType> ContestTypes { get; set; }
    public DbSet<CountingGroup> CountingGroups { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<DistrictType> DistrictTypes { get; set; }
    public DbSet<ElectionEvent> ElectionEvents { get; set; }
    public DbSet<Jurisdiction> Jurisdictions { get; set; }
    public DbSet<Mark> Marks { get; set; }
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

    // public DbSet<BallotTypeContest> BallotTypeContests { get; set; } // many-to-many defined through convention
    // public DbSet<CandidateAffiliation> CandidateAffiliations { get; set; } // many-to-many (candidate <-> party) defined through convention
    // public DbSet<CardContestOutstackCondition> CardContestOutstackConditions { get; set; } // many-to-many defined through convention
    // public DbSet<CardOutstackCondition> CardOutstackConditions { get; set; } // many-to-many defined through convention
    // public DbSet<MarkOutstackCondition> MarkOutstackConditions { get; set; } // many-to-many defined through convention
    // public DbSet<DistrictPrecinctPortion> DistrictPrecinctPortions { get; set; } // many-to-many defined through convention

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Many-To-Many

        modelBuilder.Entity<BallotType>().HasMany(bt => bt.Contests).WithMany(c => c.BallotTypes);
        modelBuilder.Entity<Contest>().HasMany(c => c.BallotTypes).WithMany(bt => bt.Contests);

        modelBuilder.Entity<Candidate>().HasMany(c => c.PartyAffiliations).WithMany(p => p.CandidateAffiliations);
        modelBuilder.Entity<Party>().HasMany(p => p.CandidateAffiliations).WithMany(c => c.PartyAffiliations);

        modelBuilder.Entity<CardContest>().HasMany(cc => cc.OutstackConditions).WithMany(oc => oc.CardContests);
        modelBuilder.Entity<Card>().HasMany(c => c.OutstackConditions).WithMany(oc => oc.Cards);
        modelBuilder.Entity<Mark>().HasMany(m => m.OutstackConditions).WithMany(oc => oc.Marks);

        modelBuilder.Entity<District>().HasMany(d => d.PrecinctPortions).WithMany(pp => pp.Districts);

        #endregion Many-To-Many


        #region One-To-Many

        modelBuilder.Entity<Candidate>().HasOne(c => c.Contest).WithMany(c => c.Candidates);
        modelBuilder.Entity<Candidate>().HasOne(c => c.CandidateType).WithMany(ct => ct.Candidates);
        modelBuilder.Entity<Card>().HasOne(c => c.Original).WithMany(o => o.Cards);
        modelBuilder.Entity<CardContest>().HasOne(cc => cc.Card).WithMany(c => CardContests);
        modelBuilder.Entity<CardContest>().HasOne(cc => cc.Contest).WithMany(c => c.CardContests);
        modelBuilder.Entity<Mark>().HasOne(m => m.CardContest).WithMany(cc => cc.Marks);

        #endregion One-To-Many


        #region One-To-One

        // nvm

        #endregion One-To-One


        #region Primary Keys

        modelBuilder.Entity<BallotType>().HasKey(bt => bt.Id);
        modelBuilder.Entity<Candidate>().HasKey(c => c.Id);
        modelBuilder.Entity<CandidateType>().HasKey(ct => ct.Id);
        modelBuilder.Entity<Card>().HasKey(c => c.Id);
        modelBuilder.Entity<CardContest>().HasKey(c => c.Id);
        modelBuilder.Entity<Contest>().HasKey(c => c.Id);

        #endregion Primary Keys


        #region Unique Constraints

        modelBuilder.Entity<BallotType>().HasIndex(bt => bt.Description).IsUnique();
        modelBuilder.Entity<CandidateType>().HasIndex(ct => ct.Description).IsUnique();

        #endregion Unique Constraints
    }
}
