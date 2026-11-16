using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class VotingLocation
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public ICollection<Tabulator>? Tabulators { get; set; }

    public VotingLocation ShallowCopy()
    {
        return (VotingLocation)MemberwiseClone();
    }
}
