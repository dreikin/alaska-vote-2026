using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Tabulator
{
    [Key] public required int Id { get; set; }

    public required string Description { get; set; }
    public string? ExternalId { get; set; }
    public required int VotingLocationId { get; set; }
    public VotingLocation? VotingLocation { get; set; }
    public required int TabulatorTypeId { get; set; }
    public TabulatorType? TabulatorType { get; set; }
    public required int ThresholdMin { get; set; }
    public required int ThresholdMax { get; set; }
    public required int WriteThresholdMin { get; set; }
    public required int WriteThresholdMax { get; set; }
    public ICollection<Session>? Sessions { get; set; }
}
