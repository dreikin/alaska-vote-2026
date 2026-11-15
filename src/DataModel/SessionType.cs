using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class SessionType
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public ICollection<Session>? Sessions { get; set; }
}
