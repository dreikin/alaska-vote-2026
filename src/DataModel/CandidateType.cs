using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class CandidateType
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public ICollection<Candidate>? Candidates { get; set; }

    public CandidateType ShallowCopy()
    {
        return (CandidateType)MemberwiseClone();
    }
}

public class CandidateTypeValueEqualityComparer : IEqualityComparer<CandidateType>
{
    public bool Equals(CandidateType? x, CandidateType? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.Description == y.Description;
    }

    public int GetHashCode(CandidateType obj)
    {
        return HashCode.Combine(obj.Id, obj.Description);
    }
}
