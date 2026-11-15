using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class ElectionEvent
{
    [Key] public required int Id { get; set; }

    public required string Description { get; set; }
    public string? ExternalId { get; set; }
    public required int JurisdictionId { get; set; }

    public Jurisdiction? Jurisdiction { get; set; }

    // TODO: EF Compatibility
    public required DateOnly ElectionDate { get; set; }

    // TODO: Data annotation - 32 bytes
    [MaxLength(32)] public required byte[] ElectionSignature { get; set; }
    public ICollection<Session>? Sessions { get; set; }
}
