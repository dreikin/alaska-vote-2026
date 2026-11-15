using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class PrecinctPortion
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public string? ExternalId { get; set; }
    [Required] public required int PrecinctId { get; set; }
    public Precinct? Precinct { get; set; }
    public ICollection<District>? Districts { get; set; }
    public ICollection<Original>? Originals { get; set; }
}
