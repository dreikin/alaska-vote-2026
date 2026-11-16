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
