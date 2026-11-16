using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class CardOutstackCondition
{
    [Required] public required int CardId { get; set; }
    public Card? Card { get; set; }
    [Required] public required int OutstackConditionId { get; set; }
    public OutstackCondition? OutstackCondition { get; set; }

    public CardOutstackCondition ShallowCopy()
    {
        return (CardOutstackCondition)MemberwiseClone();
    }
}

public class CardOutstackConditionValueEqualityComparer : IEqualityComparer<CardOutstackCondition>
{
    public bool Equals(CardOutstackCondition? x, CardOutstackCondition? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.CardId == y.CardId && x.OutstackConditionId == y.OutstackConditionId;
    }

    public int GetHashCode(CardOutstackCondition obj)
    {
        return HashCode.Combine(obj.CardId, obj.OutstackConditionId);
    }
}
