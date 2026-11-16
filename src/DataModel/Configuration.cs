using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Configuration
{
    [Key] public int Id { get; set; }
    [Required] public required bool IncludeTabulatorFilter { get; set; }
    [Required] public required int TabulatorFilterValue { get; set; }
    [Required] public required bool IncludeResultContainerFilter { get; set; }
    [Required] public required int ResultContainerFilterValue { get; set; }
    [Required] public required bool IncludeBallotTypeFilter { get; set; }
    [Required] public required int BallotTypeFilterValue { get; set; }

    // TODO: Figure out the possible value types. Empty in current sample.
    public ICollection<ContestFilter>? ContestFilter { get; set; }

    // TODO: Figure out the possible value types. Empty in current sample.
    public ICollection<PrecinctPortionFilter>? PrecinctPortionFilter { get; set; }
    [Required] public required bool SplitFilesPerBatch { get; set; }
    [Required] public required bool IncludeOnlyPublishedResultContainers { get; set; }
    [Required] public required bool UseTabulatorFormat { get; set; }
    [Required] public required bool IncludeSessionDetails { get; set; }
    [Required] public required bool IncludeMarkDensity { get; set; }
    [Required] public required int CvrType { get; set; }
    [Required] public required int CvrTurnoutTest { get; set; }
    [Required] public required int CvrSuppressionType { get; set; }
    [Required] public required int TurnoutThreshold { get; set; }
    public ICollection<OutstackCondition>? OutstackConditions { get; set; }

    public Configuration ShallowCopy()
    {
        return (Configuration)MemberwiseClone();
    }
}

public class ConfigurationValueEqualityComparer : IEqualityComparer<Configuration>
{
    public bool Equals(Configuration? x, Configuration? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.IncludeTabulatorFilter == y.IncludeTabulatorFilter &&
               x.TabulatorFilterValue == y.TabulatorFilterValue &&
               x.IncludeResultContainerFilter == y.IncludeResultContainerFilter &&
               x.ResultContainerFilterValue == y.ResultContainerFilterValue &&
               x.IncludeBallotTypeFilter == y.IncludeBallotTypeFilter &&
               x.BallotTypeFilterValue == y.BallotTypeFilterValue && x.SplitFilesPerBatch == y.SplitFilesPerBatch &&
               x.IncludeOnlyPublishedResultContainers == y.IncludeOnlyPublishedResultContainers &&
               x.UseTabulatorFormat == y.UseTabulatorFormat && x.IncludeSessionDetails == y.IncludeSessionDetails &&
               x.IncludeMarkDensity == y.IncludeMarkDensity && x.CvrType == y.CvrType &&
               x.CvrTurnoutTest == y.CvrTurnoutTest && x.CvrSuppressionType == y.CvrSuppressionType &&
               x.TurnoutThreshold == y.TurnoutThreshold;
    }

    public int GetHashCode(Configuration obj)
    {
        var hashCode = new HashCode();
        hashCode.Add(obj.Id);
        hashCode.Add(obj.IncludeTabulatorFilter);
        hashCode.Add(obj.TabulatorFilterValue);
        hashCode.Add(obj.IncludeResultContainerFilter);
        hashCode.Add(obj.ResultContainerFilterValue);
        hashCode.Add(obj.IncludeBallotTypeFilter);
        hashCode.Add(obj.BallotTypeFilterValue);
        hashCode.Add(obj.SplitFilesPerBatch);
        hashCode.Add(obj.IncludeOnlyPublishedResultContainers);
        hashCode.Add(obj.UseTabulatorFormat);
        hashCode.Add(obj.IncludeSessionDetails);
        hashCode.Add(obj.IncludeMarkDensity);
        hashCode.Add(obj.CvrType);
        hashCode.Add(obj.CvrTurnoutTest);
        hashCode.Add(obj.CvrSuppressionType);
        hashCode.Add(obj.TurnoutThreshold);
        return hashCode.ToHashCode();
    }
}
