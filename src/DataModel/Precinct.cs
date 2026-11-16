using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Precinct
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public string? ExternalId { get; set; }
    public ICollection<PrecinctPortion>? PrecinctPortions { get; set; }

    public Precinct ShallowCopy()
    {
        return (Precinct)MemberwiseClone();
    }
}

public class PrecinctValueEqualityComparer : IEqualityComparer<Precinct>
{
    public bool Equals(Precinct? x, Precinct? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.Description == y.Description && x.ExternalId == y.ExternalId;
    }

    public int GetHashCode(Precinct obj)
    {
        return HashCode.Combine(obj.Id, obj.Description, obj.ExternalId);
    }
}
