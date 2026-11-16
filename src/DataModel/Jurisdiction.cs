using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Jurisdiction
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public ICollection<ElectionEvent>? ElectionEvents { get; set; }

    public Jurisdiction ShallowCopy()
    {
        return (Jurisdiction)MemberwiseClone();
    }
}

public class JurisdictionValueEqualityComparer : IEqualityComparer<Jurisdiction>
{
    public bool Equals(Jurisdiction? x, Jurisdiction? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.Description == y.Description;
    }

    public int GetHashCode(Jurisdiction obj)
    {
        return HashCode.Combine(obj.Id, obj.Description);
    }
}
