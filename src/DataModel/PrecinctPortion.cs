using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class PrecinctPortion
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public string? ExternalId { get; set; }
    [Required] public required int PrecinctId { get; set; }
    public Precinct? Precinct { get; set; }
    public ICollection<District>? Districts { get; set; }
    public ICollection<Original>? Originals { get; set; }

    public PrecinctPortion ShallowCopy()
    {
        return (PrecinctPortion)MemberwiseClone();
    }
}

public class PrecinctPortionValueEqualityComparer : IEqualityComparer<PrecinctPortion>
{
    public bool Equals(PrecinctPortion? x, PrecinctPortion? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.Description == y.Description && x.ExternalId == y.ExternalId &&
               x.PrecinctId == y.PrecinctId;
    }

    public int GetHashCode(PrecinctPortion obj)
    {
        return HashCode.Combine(obj.Id, obj.Description, obj.ExternalId, obj.PrecinctId);
    }
}
