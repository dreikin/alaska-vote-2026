namespace DataModel;

public class Session
{
    public int Id { get; set; }
    public int ElectionEventId { get; set; }
    public ElectionEvent ElectionEvent { get; set; }
    public int TabulatorId { get; set; }
    public Tabulator Tabulator { get; set; }
    // TODO: Unknown reference.  Simply a counter?
    public int BatchId { get; set; }
    // TODO: Unknown reference. Should be the ID?
    public int RecordId { get; set; }
    public int CountingGroupId { get; set; }
    public CountingGroup CountingGroup { get; set; }
    public string ImageMask { get; set; }
    public int SessionTypeId { get; set; }
    public SessionType SessionType { get; set; }
    public string VotingSessionIdentifier { get; set; }
    public string UniqueVotingIdentifier { get; set; }
    public Original Original { get; set; }
}
