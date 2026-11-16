using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class TabulatorType
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public ICollection<Tabulator>? Tabulators { get; set; }

    public TabulatorType ShallowCopy()
    {
        return (TabulatorType)MemberwiseClone();
    }
}
