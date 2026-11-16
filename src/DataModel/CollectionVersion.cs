using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class CollectionVersion
{
    [Key] public int Id { get; set; }
    [Required] public required string Name { get; set; }
    [Required] public required string Version { get; set; }

    public CollectionVersion ShallowCopy()
    {
        return (CollectionVersion)MemberwiseClone();
    }
}

public class CollectionVersionValueEqualityComparer : IEqualityComparer<CollectionVersion>
{
    public bool Equals(CollectionVersion? x, CollectionVersion? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.Name == y.Name && x.Version == y.Version;
    }

    public int GetHashCode(CollectionVersion obj)
    {
        return HashCode.Combine(obj.Id, obj.Name, obj.Version);
    }
}
