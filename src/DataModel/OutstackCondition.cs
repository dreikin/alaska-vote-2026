using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class OutstackCondition
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public ICollection<CardContest>? CardContests { get; set; }
    public ICollection<Card>? Cards { get; set; }
    public ICollection<Configuration>? Configurations { get; set; }
    public ICollection<Mark>? Marks { get; set; }

    public OutstackCondition ShallowCopy()
    {
        return (OutstackCondition)MemberwiseClone();
    }
}

public class OutstackConditionValueEqualityComparer : IEqualityComparer<OutstackCondition>
{
    public bool Equals(OutstackCondition? x, OutstackCondition? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.Description == y.Description;
    }

    public int GetHashCode(OutstackCondition obj)
    {
        return HashCode.Combine(obj.Id, obj.Description);
    }
}
