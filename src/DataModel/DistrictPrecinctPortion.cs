using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class DistrictPrecinctPortion
{
    [Required] public required int DistrictId { get; set; }
    public District? District { get; set; }
    [Required] public required int PrecinctPortionId { get; set; }
    public PrecinctPortion? PrecinctPortion { get; set; }

    public DistrictPrecinctPortion ShallowCopy()
    {
        return (DistrictPrecinctPortion)MemberwiseClone();
    }
}

public class DistrictPrecinctPortionValueEqualityComparer : IEqualityComparer<DistrictPrecinctPortion>
{
    public bool Equals(DistrictPrecinctPortion? x, DistrictPrecinctPortion? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.DistrictId == y.DistrictId && x.PrecinctPortionId == y.PrecinctPortionId;
    }

    public int GetHashCode(DistrictPrecinctPortion obj)
    {
        return HashCode.Combine(obj.DistrictId, obj.PrecinctPortionId);
    }
}
