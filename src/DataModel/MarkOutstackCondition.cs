using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class MarkOutstackCondition
{
    [Required] public required int MarkId { get; set; }
    public Mark? Mark { get; set; }
    [Required] public required int OutstackConditionId { get; set; }
    public OutstackCondition? OutstackCondition { get; set; }

    public MarkOutstackCondition ShallowCopy()
    {
        return (MarkOutstackCondition)MemberwiseClone();
    }
}

public class MarkOutstackConditionValueEqualityComparer : IEqualityComparer<MarkOutstackCondition>
{
    public bool Equals(MarkOutstackCondition? x, MarkOutstackCondition? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.MarkId == y.MarkId && x.OutstackConditionId == y.OutstackConditionId;
    }

    public int GetHashCode(MarkOutstackCondition obj)
    {
        return HashCode.Combine(obj.MarkId, obj.OutstackConditionId);
    }
}
