using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class ElectionEvent
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public string? ExternalId { get; set; }
    [Required] public required int JurisdictionId { get; set; }
    public Jurisdiction? Jurisdiction { get; set; }

    // TODO: EF Compatibility
    [Required] public required DateOnly ElectionDate { get; set; }

    // TODO: Data annotation - 32 bytes
    [Required] [MaxLength(32)] public required byte[] ElectionSignature { get; set; }
    public ICollection<Session>? Sessions { get; set; }
}
