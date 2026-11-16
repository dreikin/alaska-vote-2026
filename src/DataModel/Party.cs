using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Party
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public string? ExternalId { get; set; }
    public ICollection<Candidate>? CandidateAffiliations { get; set; }
    public ICollection<Mark>? Marks { get; set; }

    public Party ShallowCopy()
    {
        return (Party)MemberwiseClone();
    }
}

public class PartyValueEqualityComparer : IEqualityComparer<Party>
{
    public bool Equals(Party? x, Party? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.Description == y.Description && x.ExternalId == y.ExternalId;
    }

    public int GetHashCode(Party obj)
    {
        return HashCode.Combine(obj.Id, obj.Description, obj.ExternalId);
    }
}
