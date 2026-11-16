using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class PrecinctPortionFilter
{
    [Key] public int Id { get; set; }
    [Required] public required int ConfigurationId { get; set; }
    public Configuration? Configuration { get; set; }

    public PrecinctPortionFilter ShallowCopy()
    {
        return (PrecinctPortionFilter)MemberwiseClone();
    }
}

public class PrecinctPortionFilterValueEqualityComparer : IEqualityComparer<PrecinctPortionFilter>
{
    public bool Equals(PrecinctPortionFilter? x, PrecinctPortionFilter? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.ConfigurationId == y.ConfigurationId;
    }

    public int GetHashCode(PrecinctPortionFilter obj)
    {
        return HashCode.Combine(obj.Id, obj.ConfigurationId);
    }
}
