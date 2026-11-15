using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class District
{
    [Key] public required int Id { get; set; }

    public required string Description { get; set; }
    public string? ExternalId { get; set; }
    public required Guid DistrictTypeId { get; set; }
    public DistrictType? DistrictType { get; set; }
    public ICollection<Contest>? Contests { get; set; }
    public ICollection<PrecinctPortion>? PrecinctPortions { get; set; }
}
