using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class CardContestOutstackCondition
{
    [Required] public required int CardContestId { get; set; }
    public CardContest? CardContest { get; set; }
    [Required] public required int OutstackConditionId { get; set; }
    public OutstackCondition? OutstackCondition { get; set; }

    public CardContestOutstackCondition ShallowCopy()
    {
        return (CardContestOutstackCondition)MemberwiseClone();
    }
}

public class CardContestOutstackConditionValueEqualityComparer : IEqualityComparer<CardContestOutstackCondition>
{
    public bool Equals(CardContestOutstackCondition? x, CardContestOutstackCondition? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.CardContestId == y.CardContestId && x.OutstackConditionId == y.OutstackConditionId;
    }

    public int GetHashCode(CardContestOutstackCondition obj)
    {
        return HashCode.Combine(obj.CardContestId, obj.OutstackConditionId);
    }
}
