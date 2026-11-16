using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class VotingLocation
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public ICollection<Tabulator>? Tabulators { get; set; }

    public VotingLocation ShallowCopy()
    {
        return (VotingLocation)MemberwiseClone();
    }
}

public class VotingLocationValueEqualityComparer : IEqualityComparer<VotingLocation>
{
    public bool Equals(VotingLocation? x, VotingLocation? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.Description == y.Description;
    }

    public int GetHashCode(VotingLocation obj)
    {
        return HashCode.Combine(obj.Id, obj.Description);
    }
}
