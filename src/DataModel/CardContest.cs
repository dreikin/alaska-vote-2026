using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class CardContest
{
    [Key] public int Id { get; set; }
    [Required] public required int ManifestationId { get; set; }
    [Required] public required int CardId { get; set; }
    public Card? Card { get; set; }
    [Required] public required int ContestId { get; set; } // Id
    public Contest? Contest { get; set; }
    [Required] public required int Undervotes { get; set; }
    [Required] public required int Overvotes { get; set; }
    public ICollection<OutstackCondition>? OutstackConditions { get; set; }
    public ICollection<Mark>? Marks { get; set; }

    public CardContest ShallowCopy()
    {
        return (CardContest)MemberwiseClone();
    }
}

public class CardContestValueEqualityComparer : IEqualityComparer<CardContest>
{
    public bool Equals(CardContest? x, CardContest? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.ManifestationId == y.ManifestationId && x.CardId == y.CardId &&
               x.ContestId == y.ContestId && x.Undervotes == y.Undervotes && x.Overvotes == y.Overvotes;
    }

    public int GetHashCode(CardContest obj)
    {
        return HashCode.Combine(obj.Id, obj.ManifestationId, obj.CardId, obj.ContestId, obj.Undervotes, obj.Overvotes);
    }
}
