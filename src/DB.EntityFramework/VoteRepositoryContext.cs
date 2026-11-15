using DataModel;
using Microsoft.EntityFrameworkCore;

namespace DB.EntityFramework;

public class VoteRepositoryContext(DbContextOptions<VoteRepositoryContext> options) : DbContext(options)
{
    // Many-to-many collections defined through convention:
    // public DbSet<BallotTypeContest> BallotTypeContests { get; set; }
    // public DbSet<CandidateAffiliation> CandidateAffiliations { get; set; } // candidate <-> party)
    // public DbSet<CardContestOutstackCondition> CardContestOutstackConditions { get; set; }
    // public DbSet<CardOutstackCondition> CardOutstackConditions { get; set; }
    // public DbSet<MarkOutstackCondition> MarkOutstackConditions { get; set; }
    // public DbSet<DistrictPrecinctPortion> DistrictPrecinctPortions { get; set; }

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
    public DbSet<CollectionVersion> CollectionVersions { get; set; }
    public DbSet<Tabulator> Tabulators { get; set; }
    public DbSet<TabulatorType> TabulatorTypes { get; set; }
    public DbSet<VotingLocation> VotingLocations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Many-To-Many

        modelBuilder.Entity<Contest>().HasMany(c => c.BallotTypes).WithMany(bt => bt.Contests);
        modelBuilder.Entity<Candidate>().HasMany(c => c.PartyAffiliations).WithMany(p => p.CandidateAffiliations);
        modelBuilder.Entity<District>().HasMany(d => d.PrecinctPortions).WithMany(pp => pp.Districts);

        modelBuilder.Entity<CardContest>().HasMany(cc => cc.OutstackConditions).WithMany(oc => oc.CardContests);
        modelBuilder.Entity<Card>().HasMany(c => c.OutstackConditions).WithMany(oc => oc.Cards);
        modelBuilder.Entity<Configuration>().HasMany(c => c.OutstackConditions).WithMany(oc => oc.Configurations);
        modelBuilder.Entity<Mark>().HasMany(m => m.OutstackConditions).WithMany(oc => oc.Marks);

        #endregion Many-To-Many


        #region One-To-Many

        modelBuilder.Entity<Candidate>().HasOne(c => c.Contest).WithMany(c => c.Candidates);
        modelBuilder.Entity<Candidate>().HasOne(c => c.CandidateType).WithMany(ct => ct.Candidates);
        modelBuilder.Entity<Card>().HasOne(c => c.Original).WithMany(o => o.Cards);
        modelBuilder.Entity<CardContest>().HasOne(cc => cc.Card).WithMany(c => c.CardContests);
        modelBuilder.Entity<CardContest>().HasOne(cc => cc.Contest).WithMany(c => c.CardContests);
        modelBuilder.Entity<Contest>().HasOne(c => c.District).WithMany(d => d.Contests);
        modelBuilder.Entity<Contest>().HasOne(c => c.ContestType).WithMany(ct => ct.Contests);
        modelBuilder.Entity<ContestFilter>().HasOne(cf => cf.Configuration).WithMany(c => c.ContestFilter);
        modelBuilder.Entity<District>().HasOne(d => d.DistrictType).WithMany(dt => dt.Districts);
        modelBuilder.Entity<ElectionEvent>().HasOne(ee => ee.Jurisdiction).WithMany(j => j.ElectionEvents);
        modelBuilder.Entity<Mark>().HasOne(m => m.CardContest).WithMany(cc => cc.Marks);
        modelBuilder.Entity<Mark>().HasOne(m => m.Candidate).WithMany(c => c.Marks);
        modelBuilder.Entity<Mark>().HasOne(m => m.Party).WithMany(p => p.Marks);
        modelBuilder.Entity<Original>().HasOne(o => o.PrecinctPortion).WithMany(pp => pp.Originals);
        modelBuilder.Entity<Original>().HasOne(o => o.BallotType).WithMany(bt => bt.Originals);
        modelBuilder.Entity<PrecinctPortion>().HasOne(pp => pp.Precinct).WithMany(p => p.PrecinctPortions);
        modelBuilder.Entity<PrecinctPortionFilter>().HasOne(ppf => ppf.Configuration)
            .WithMany(c => c.PrecinctPortionFilter);
        modelBuilder.Entity<Session>().HasOne(s => s.ElectionEvent).WithMany(ee => ee.Sessions);
        modelBuilder.Entity<Session>().HasOne(s => s.Tabulator).WithMany(t => t.Sessions);
        modelBuilder.Entity<Session>().HasOne(s => s.CountingGroup).WithMany(cc => cc.Sessions);
        modelBuilder.Entity<Session>().HasOne(s => s.SessionType).WithMany(st => st.Sessions);
        modelBuilder.Entity<Tabulator>().HasOne(t => t.VotingLocation).WithMany(vl => vl.Tabulators);
        modelBuilder.Entity<Tabulator>().HasOne(t => t.TabulatorType).WithMany(tt => tt.Tabulators);

        #endregion One-To-Many


        #region One-To-One

        modelBuilder.Entity<Original>().HasOne(o => o.Session).WithOne(s => s.Original);

        #endregion One-To-One


        #region Unique Constraints

        modelBuilder.Entity<BallotType>().HasIndex(bt => bt.Description).IsUnique();
        modelBuilder.Entity<CandidateType>().HasIndex(ct => ct.Description).IsUnique();
        modelBuilder.Entity<ContestType>().HasIndex(ct => ct.Description).IsUnique();
        modelBuilder.Entity<DistrictType>().HasIndex(dt => dt.Description).IsUnique();
        modelBuilder.Entity<Jurisdiction>().HasIndex(j => j.Description).IsUnique();
        modelBuilder.Entity<OutstackCondition>().HasIndex(oc => oc.Description).IsUnique();
        modelBuilder.Entity<Party>().HasIndex(p => p.Description).IsUnique();
        modelBuilder.Entity<Precinct>().HasIndex(p => p.Description).IsUnique();
        modelBuilder.Entity<SessionType>().HasIndex(st => st.Description).IsUnique();
        modelBuilder.Entity<CollectionVersion>().HasIndex(tv => new { tv.Name, tv.Version }).IsUnique();
        modelBuilder.Entity<TabulatorType>().HasIndex(tt => tt.Description).IsUnique();
        modelBuilder.Entity<VotingLocation>().HasIndex(vl => vl.Description).IsUnique();

        #endregion Unique Constraints
    }
}
