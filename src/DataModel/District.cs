using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class District
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public string? ExternalId { get; set; }
    [Required] public required Guid DistrictTypeId { get; set; }
    public DistrictType? DistrictType { get; set; }
    public ICollection<Contest>? Contests { get; set; }
    public ICollection<PrecinctPortion>? PrecinctPortions { get; set; }

    public District ShallowCopy()
    {
        return (District)MemberwiseClone();
    }
}

public class DistrictValueEqualityComparer : IEqualityComparer<District>
{
    public bool Equals(District? x, District? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.Description == y.Description && x.ExternalId == y.ExternalId &&
               x.DistrictTypeId.Equals(y.DistrictTypeId);
    }

    public int GetHashCode(District obj)
    {
        return HashCode.Combine(obj.Id, obj.Description, obj.ExternalId, obj.DistrictTypeId);
    }
}
