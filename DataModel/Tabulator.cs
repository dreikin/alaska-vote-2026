namespace DataModel;

public class Tabulator
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string ExternalId { get; set; }
    public int VotingLocationId { get; set; }
    public VotingLocation VotingLocation { get; set; }
    public int TabulatorTypeId { get; set; }
    public TabulatorType TabulatorType { get; set; }
    public int ThresholdMin { get; set; }
    public int ThresholdMax { get; set; }
    public int WriteThresholdMin { get; set; }
    public int WriteThresholdMax { get; set; }
}
