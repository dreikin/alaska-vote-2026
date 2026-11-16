using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class CountingGroup
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public string? ExternalId { get; set; }
    public ICollection<Session>? Sessions { get; set; }

    public CountingGroup ShallowCopy()
    {
        return (CountingGroup)MemberwiseClone();
    }
}

public class CountingGroupValueEqualityComparer : IEqualityComparer<CountingGroup>
{
    public bool Equals(CountingGroup? x, CountingGroup? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.Description == y.Description && x.ExternalId == y.ExternalId;
    }

    public int GetHashCode(CountingGroup obj)
    {
        return HashCode.Combine(obj.Id, obj.Description, obj.ExternalId);
    }
}
