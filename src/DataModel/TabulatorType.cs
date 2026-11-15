using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class TabulatorType
{
    [Key] public required int Id { get; set; }

    public required string Description { get; set; }
    public ICollection<Tabulator>? Tabulators { get; set; }
}
