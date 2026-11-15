using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class ContestType
{
    [Key] public required int Id { get; set; }

    public required string Description { get; set; }
    public ICollection<Contest>? Contests { get; set; }
}
