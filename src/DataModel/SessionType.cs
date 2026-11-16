using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class SessionType
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public ICollection<Session>? Sessions { get; set; }

    public SessionType ShallowCopy()
    {
        return (SessionType)MemberwiseClone();
    }
}

public class SessionTypeValueEqualityComparer : IEqualityComparer<SessionType>
{
    public bool Equals(SessionType? x, SessionType? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.Description == y.Description;
    }

    public int GetHashCode(SessionType obj)
    {
        return HashCode.Combine(obj.Id, obj.Description);
    }
}
