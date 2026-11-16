using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class BallotTypeContest
{
    [Required] public required int BallotTypeId { get; set; }
    public BallotType? BallotType { get; set; }
    [Required] public required int ContestId { get; set; }
    public Contest? Contest { get; set; }

    public BallotTypeContest ShallowCopy()
    {
        return (BallotTypeContest)MemberwiseClone();
    }
}

public class BallotTypeContestValueEqualityComparer : IEqualityComparer<BallotTypeContest>
{
    public bool Equals(BallotTypeContest? x, BallotTypeContest? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.BallotTypeId == y.BallotTypeId && x.ContestId == y.ContestId;
    }

    public int GetHashCode(BallotTypeContest obj)
    {
        return HashCode.Combine(obj.BallotTypeId, obj.ContestId);
    }
}
