using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Session
{
    [Key] public int Id { get; set; }
    [Required] public required int ElectionEventId { get; set; }
    public ElectionEvent? ElectionEvent { get; set; }
    [Required] public required int TabulatorId { get; set; }
    public Tabulator? Tabulator { get; set; }

    // TODO: Unknown reference.  Simply a counter?
    [Required] public required int BatchId { get; set; }

    // TODO: Unknown reference. Should be the ID?
    [Required] public required int RecordId { get; set; }
    [Required] public required int CountingGroupId { get; set; }
    public CountingGroup? CountingGroup { get; set; }
    [Required] public required string ImageMask { get; set; }
    [Required] public required int SessionTypeId { get; set; }
    public SessionType? SessionType { get; set; }
    public string? VotingSessionIdentifier { get; set; }
    public string? UniqueVotingIdentifier { get; set; }
    public Original? Original { get; set; }

    public Session ShallowCopy()
    {
        return (Session)MemberwiseClone();
    }
}

public class SessionValueEqualityComparer : IEqualityComparer<Session>
{
    public bool Equals(Session? x, Session? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.ElectionEventId == y.ElectionEventId && x.TabulatorId == y.TabulatorId &&
               x.BatchId == y.BatchId && x.RecordId == y.RecordId && x.CountingGroupId == y.CountingGroupId &&
               x.ImageMask == y.ImageMask && x.SessionTypeId == y.SessionTypeId &&
               x.VotingSessionIdentifier == y.VotingSessionIdentifier &&
               x.UniqueVotingIdentifier == y.UniqueVotingIdentifier;
    }

    public int GetHashCode(Session obj)
    {
        var hashCode = new HashCode();
        hashCode.Add(obj.Id);
        hashCode.Add(obj.ElectionEventId);
        hashCode.Add(obj.TabulatorId);
        hashCode.Add(obj.BatchId);
        hashCode.Add(obj.RecordId);
        hashCode.Add(obj.CountingGroupId);
        hashCode.Add(obj.ImageMask);
        hashCode.Add(obj.SessionTypeId);
        hashCode.Add(obj.VotingSessionIdentifier);
        hashCode.Add(obj.UniqueVotingIdentifier);
        return hashCode.ToHashCode();
    }
}
