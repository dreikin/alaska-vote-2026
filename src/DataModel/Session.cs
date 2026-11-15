using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Session
{
    [Key] public int Id { get; set; }
    [Required] public required int ElectionEventId { get; set; }
    public ElectionEvent? ElectionEvent { get; set; }
    [Required] public required int TabulatorId { get; set; }
    public Tabulator? Tabulator { get; set; }

    // TODO: Unknown reference.  Simply a counter?
    [Required] public required int BatchId { get; set; }

    // TODO: Unknown reference. Should be the ID?
    [Required] public required int RecordId { get; set; }
    [Required] public required int CountingGroupId { get; set; }
    public CountingGroup? CountingGroup { get; set; }
    [Required] public required string ImageMask { get; set; }
    [Required] public required int SessionTypeId { get; set; }
    public SessionType? SessionType { get; set; }
    public string? VotingSessionIdentifier { get; set; }
    public string? UniqueVotingIdentifier { get; set; }
    public Original? Original { get; set; }
}
