using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Tabulator
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public string? ExternalId { get; set; }
    [Required] public required int VotingLocationId { get; set; }
    public VotingLocation? VotingLocation { get; set; }
    [Required] public required int TabulatorTypeId { get; set; }
    public TabulatorType? TabulatorType { get; set; }
    [Required] public required int ThresholdMin { get; set; }
    [Required] public required int ThresholdMax { get; set; }
    [Required] public required int WriteThresholdMin { get; set; }
    [Required] public required int WriteThresholdMax { get; set; }
    public ICollection<Session>? Sessions { get; set; }

    public Tabulator ShallowCopy()
    {
        return (Tabulator)MemberwiseClone();
    }
}

public class TabulatorValueEqualityComparer : IEqualityComparer<Tabulator>
{
    public bool Equals(Tabulator? x, Tabulator? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.Description == y.Description && x.ExternalId == y.ExternalId &&
               x.VotingLocationId == y.VotingLocationId && x.TabulatorTypeId == y.TabulatorTypeId &&
               x.ThresholdMin == y.ThresholdMin && x.ThresholdMax == y.ThresholdMax &&
               x.WriteThresholdMin == y.WriteThresholdMin && x.WriteThresholdMax == y.WriteThresholdMax;
    }

    public int GetHashCode(Tabulator obj)
    {
        var hashCode = new HashCode();
        hashCode.Add(obj.Id);
        hashCode.Add(obj.Description);
        hashCode.Add(obj.ExternalId);
        hashCode.Add(obj.VotingLocationId);
        hashCode.Add(obj.TabulatorTypeId);
        hashCode.Add(obj.ThresholdMin);
        hashCode.Add(obj.ThresholdMax);
        hashCode.Add(obj.WriteThresholdMin);
        hashCode.Add(obj.WriteThresholdMax);
        return hashCode.ToHashCode();
    }
}
