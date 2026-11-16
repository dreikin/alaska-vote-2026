using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Contest
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public string? ExternalId { get; set; }
    [Required] public required int DistrictId { get; set; }
    public District? District { get; set; }

    // (Presumably) How many people can win a contest.  Usually 1.
    [Required] public required int VoteFor { get; set; }

    // (Presumably) How many ranks a voter can use for RCV in the contest.
    [Required] public required int NumOfRanks { get; set; }

    // (Presumably) How many names can be written-in by a voter.
    [Required] public required int NumOfWriteins { get; set; }
    [Required] public required bool Disabled { get; set; }
    [Required] public required int ContestTypeId { get; set; }
    public ContestType? ContestType { get; set; }
    public ICollection<BallotType>? BallotTypes { get; set; }
    public ICollection<Candidate>? Candidates { get; set; }
    public ICollection<CardContest>? CardContests { get; set; }

    public Contest ShallowCopy()
    {
        return (Contest)MemberwiseClone();
    }
}

public class ContestValueEqualityComparer : IEqualityComparer<Contest>
{
    public bool Equals(Contest? x, Contest? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.Description == y.Description && x.ExternalId == y.ExternalId &&
               x.DistrictId == y.DistrictId && x.VoteFor == y.VoteFor && x.NumOfRanks == y.NumOfRanks &&
               x.NumOfWriteins == y.NumOfWriteins && x.Disabled == y.Disabled && x.ContestTypeId == y.ContestTypeId;
    }

    public int GetHashCode(Contest obj)
    {
        var hashCode = new HashCode();
        hashCode.Add(obj.Id);
        hashCode.Add(obj.Description);
        hashCode.Add(obj.ExternalId);
        hashCode.Add(obj.DistrictId);
        hashCode.Add(obj.VoteFor);
        hashCode.Add(obj.NumOfRanks);
        hashCode.Add(obj.NumOfWriteins);
        hashCode.Add(obj.Disabled);
        hashCode.Add(obj.ContestTypeId);
        return hashCode.ToHashCode();
    }
}
