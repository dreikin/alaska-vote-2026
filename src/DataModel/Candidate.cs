using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Candidate
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public string? ExternalId { get; set; }
    [Required] public required int ContestId { get; set; }
    public Contest? Contest { get; set; }
    [Required] public required int CandidateTypeId { get; set; }
    public CandidateType? CandidateType { get; set; }
    [Required] public required bool Disabled { get; set; }
    public ICollection<Mark>? Marks { get; set; }
    public ICollection<Party>? PartyAffiliations { get; set; }

    public Candidate ShallowCopy()
    {
        return (Candidate)MemberwiseClone();
    }
}

public class CandidateValueEqualityComparer : IEqualityComparer<Candidate>
{
    public bool Equals(Candidate? x, Candidate? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.Description == y.Description && x.ExternalId == y.ExternalId &&
               x.ContestId == y.ContestId && x.CandidateTypeId == y.CandidateTypeId && x.Disabled == y.Disabled;
    }

    public int GetHashCode(Candidate obj)
    {
        return HashCode.Combine(obj.Id, obj.Description, obj.ExternalId, obj.ContestId, obj.CandidateTypeId,
            obj.Disabled);
    }
}
