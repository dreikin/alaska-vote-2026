namespace DataModel;

public class ElectionEvent
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string ExternalId { get; set; }
    public int JurisdictionId { get; set; }
    public Jurisdiction Jurisdiction { get; set; }
    // TODO: EF Compatibility
    public DateOnly ElectionDate { get; set; }
    // TODO: Data annotation - 32 bytes
    public byte[] ElectionSignature { get; set; }
}
