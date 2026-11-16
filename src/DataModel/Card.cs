using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Card
{
    [Key] public int Id { get; set; }

    // This is Id in the source.
    // TODO: Make sure this doesn't create a shadow property for the key.
    [Required] public required int CardId { get; set; }
    [Required] public required int KeyInId { get; set; }
    [Required] public required int PaperIndex { get; set; }
    [Required] public required int OriginalId { get; set; }
    public Original? Original { get; set; }
    public ICollection<CardContest>? CardContests { get; set; }
    public ICollection<OutstackCondition>? OutstackConditions { get; set; }

    public Card ShallowCopy()
    {
        return (Card)MemberwiseClone();
    }
}

public class CardValueEqualityComparer : IEqualityComparer<Card>
{
    public bool Equals(Card? x, Card? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.CardId == y.CardId && x.KeyInId == y.KeyInId && x.PaperIndex == y.PaperIndex &&
               x.OriginalId == y.OriginalId;
    }

    public int GetHashCode(Card obj)
    {
        return HashCode.Combine(obj.Id, obj.CardId, obj.KeyInId, obj.PaperIndex, obj.OriginalId);
    }
}
