using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class ContestType
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public ICollection<Contest>? Contests { get; set; }

    public ContestType ShallowCopy()
    {
        return (ContestType)MemberwiseClone();
    }
}
