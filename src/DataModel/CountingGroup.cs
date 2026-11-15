using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class CountingGroup
{
    [Key] public required int Id { get; set; }

    public required string Description { get; set; }
    public string? ExternalId { get; set; }
    public ICollection<Session>? Sessions { get; set; }
}
