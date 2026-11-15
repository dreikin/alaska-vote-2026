using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Session
{
    [Key] public required int Id { get; set; }

    public required int ElectionEventId { get; set; }
    public ElectionEvent? ElectionEvent { get; set; }
    public required int TabulatorId { get; set; }
    public Tabulator? Tabulator { get; set; }

    // TODO: Unknown reference.  Simply a counter?
    public required int BatchId { get; set; }

    // TODO: Unknown reference. Should be the ID?
    public required int RecordId { get; set; }
    public required int CountingGroupId { get; set; }
    public CountingGroup? CountingGroup { get; set; }
    public required string ImageMask { get; set; }
    public required int SessionTypeId { get; set; }
    public SessionType? SessionType { get; set; }
    public string? VotingSessionIdentifier { get; set; }
    public string? UniqueVotingIdentifier { get; set; }
    public Original? Original { get; set; }
}
