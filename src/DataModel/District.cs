using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class District
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public string? ExternalId { get; set; }
    [Required] public required Guid DistrictTypeId { get; set; }
    public DistrictType? DistrictType { get; set; }
    public ICollection<Contest>? Contests { get; set; }
    public ICollection<PrecinctPortion>? PrecinctPortions { get; set; }
}
