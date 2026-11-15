using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class TableVersion
{
    [Key] public required int Id { get; set; }

    public required string Name { get; set; }
    public required string Version { get; set; }
}
