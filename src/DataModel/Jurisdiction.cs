using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Jurisdiction
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public ICollection<ElectionEvent>? ElectionEvents { get; set; }

    public Jurisdiction ShallowCopy()
    {
        return (Jurisdiction)MemberwiseClone();
    }
}
