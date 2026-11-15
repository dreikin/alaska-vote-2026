using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class BallotType
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public string? ExternalId { get; set; }
    public ICollection<Contest>? Contests { get; set; }
    public ICollection<Original>? Originals { get; set; }
}
