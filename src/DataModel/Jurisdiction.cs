using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Jurisdiction
{
    [Key] public required int Id { get; set; }

    public required string Description { get; set; }
    public ICollection<ElectionEvent>? ElectionEvents { get; set; }
}
