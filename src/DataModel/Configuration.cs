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
}
