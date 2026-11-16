using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Original
{
    [Key] public int Id { get; set; }
    [Required] public required int PrecinctPortionId { get; set; }
    public PrecinctPortion? PrecinctPortion { get; set; }
    [Required] public required int BallotTypeId { get; set; }
    public BallotType? BallotType { get; set; }
    [Required] public required bool IsCurrent { get; set; }
    [Required] public required int SessionId { get; set; }
    public Session? Session { get; set; }
    public ICollection<Card>? Cards { get; set; }

    public Original ShallowCopy()
    {
        return (Original)MemberwiseClone();
    }
}

public class OriginalValueEqualityComparer : IEqualityComparer<Original>
{
    public bool Equals(Original? x, Original? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.PrecinctPortionId == y.PrecinctPortionId && x.BallotTypeId == y.BallotTypeId &&
               x.IsCurrent == y.IsCurrent && x.SessionId == y.SessionId;
    }

    public int GetHashCode(Original obj)
    {
        return HashCode.Combine(obj.Id, obj.PrecinctPortionId, obj.BallotTypeId, obj.IsCurrent, obj.SessionId);
    }
}
