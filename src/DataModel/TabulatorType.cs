using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class TabulatorType
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public ICollection<Tabulator>? Tabulators { get; set; }

    public TabulatorType ShallowCopy()
    {
        return (TabulatorType)MemberwiseClone();
    }
}

public class TabulatorTypeValueEqualityComparer : IEqualityComparer<TabulatorType>
{
    public bool Equals(TabulatorType? x, TabulatorType? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.Description == y.Description;
    }

    public int GetHashCode(TabulatorType obj)
    {
        return HashCode.Combine(obj.Id, obj.Description);
    }
}
