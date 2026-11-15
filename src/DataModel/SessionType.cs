using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class SessionType
{
    [Key] public required int Id { get; set; }

    public required string Description { get; set; }
    public ICollection<Session>? Sessions { get; set; }
}
