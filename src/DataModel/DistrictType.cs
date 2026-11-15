using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class DistrictType
{
    [Key] public Guid Id { get; set; }
    [Required] public required string Description { get; set; }
    public string? ExternalId { get; set; }
    public ICollection<District>? Districts { get; set; }
}
