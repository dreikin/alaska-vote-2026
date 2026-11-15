using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class BallotType
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public string? ExternalId { get; set; }
    public ICollection<Contest>? Contests { get; set; }
    public ICollection<Original>? Originals { get; set; }
}

public class BallotTypeEqualityComparer : IEqualityComparer<BallotType>
{
    public bool Equals(BallotType? x, BallotType? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.Description == y.Description && x.ExternalId == y.ExternalId;
    }

    public int GetHashCode(BallotType obj)
    {
        return HashCode.Combine(obj.Id, obj.Description, obj.ExternalId);
    }
}
