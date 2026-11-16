using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class ContestType
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public ICollection<Contest>? Contests { get; set; }

    public ContestType ShallowCopy()
    {
        return (ContestType)MemberwiseClone();
    }
}

public class ContestTypeValueEqualityComparer : IEqualityComparer<ContestType>
{
    public bool Equals(ContestType? x, ContestType? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.Description == y.Description;
    }

    public int GetHashCode(ContestType obj)
    {
        return HashCode.Combine(obj.Id, obj.Description);
    }
}
