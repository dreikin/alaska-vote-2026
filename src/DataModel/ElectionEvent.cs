using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class ElectionEvent
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public string? ExternalId { get; set; }
    [Required] public required int JurisdictionId { get; set; }
    public Jurisdiction? Jurisdiction { get; set; }

    // TODO: EF Compatibility
    [Required] public required DateOnly ElectionDate { get; set; }

    // TODO: Data annotation - 32 bytes
    [Required] [MaxLength(32)] public required byte[] ElectionSignature { get; set; }
    public ICollection<Session>? Sessions { get; set; }

    public ElectionEvent ShallowCopy()
    {
        return (ElectionEvent)MemberwiseClone();
    }
}

public class ElectionEventValueEqualityComparer : IEqualityComparer<ElectionEvent>
{
    public bool Equals(ElectionEvent? x, ElectionEvent? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.Description == y.Description && x.ExternalId == y.ExternalId &&
               x.JurisdictionId == y.JurisdictionId && x.ElectionDate.Equals(y.ElectionDate) &&
               x.ElectionSignature.Equals(y.ElectionSignature);
    }

    public int GetHashCode(ElectionEvent obj)
    {
        return HashCode.Combine(obj.Id, obj.Description, obj.ExternalId, obj.JurisdictionId, obj.ElectionDate,
            obj.ElectionSignature);
    }
}
