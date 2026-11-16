using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class DistrictType
{
    [Key] public Guid Id { get; set; }
    [Required] public required string Description { get; set; }
    public string? ExternalId { get; set; }
    public ICollection<District>? Districts { get; set; }

    public DistrictType ShallowCopy()
    {
        return (DistrictType)MemberwiseClone();
    }
}

public class DistrictTypeValueEqualityComparer : IEqualityComparer<DistrictType>
{
    public bool Equals(DistrictType? x, DistrictType? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id.Equals(y.Id) && x.Description == y.Description && x.ExternalId == y.ExternalId;
    }

    public int GetHashCode(DistrictType obj)
    {
        return HashCode.Combine(obj.Id, obj.Description, obj.ExternalId);
    }
}
