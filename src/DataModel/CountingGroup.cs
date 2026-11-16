using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class CountingGroup
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public string? ExternalId { get; set; }
    public ICollection<Session>? Sessions { get; set; }

    public CountingGroup ShallowCopy()
    {
        return (CountingGroup)MemberwiseClone();
    }
}
