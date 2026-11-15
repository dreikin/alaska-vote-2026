using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class TableVersion
{
    [Key] public int Id { get; set; }
    [Required] public required string Name { get; set; }
    [Required] public required string Version { get; set; }
}
