namespace DataModel;

public class Configuration
{
    public required bool IncludeTabulatorFilter { get; set; }
    public required int TabulatorFilterValue { get; set; }
    public required bool IncludeResultContainerFilter { get; set; }
    public required int ResultContainerFilterValue { get; set; }
    public required bool IncludeBallotTypeFilter { get; set; }
    public required int BallotTypeFilterValue { get; set; }
    public required ICollection<ContestFilter> ContestFilter { get; set; }
    public required ICollection<PrecinctPortionFilter> PrecinctPortionFilter { get; set; }
    public required bool SplitFilesPerBatch { get; set; }
    public required bool IncludeOnlyPublishedResultContainers { get; set; }
    public required bool UseTabulatorFormat { get; set; }
    public required bool IncludeSessionDetails { get; set; }
    public required bool IncludeMarkDensity { get; set; }
    public required int CvrType { get; set; }
    public required int CvrTurnoutTest { get; set; }
    public required int CvrSuppressionType { get; set; }
    public required int TurnoutThreshold { get; set; }
    public required ICollection<OutstackCondition> OutstackConditions { get; set; }
}
