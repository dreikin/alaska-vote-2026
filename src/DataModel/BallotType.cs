using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class BallotType
{
    [Key] public required int Id { get; set; }

    public required string Description { get; set; }
    public string? ExternalId { get; set; }
    public ICollection<Contest>? Contests { get; set; }
    public ICollection<Original>? Originals { get; set; }
}
