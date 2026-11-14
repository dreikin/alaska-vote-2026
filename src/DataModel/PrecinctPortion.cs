namespace DataModel;

public class PrecinctPortion
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string ExternalId { get; set; }
    public int PrecinctId { get; set; }
    public Precinct Precinct { get; set; }
}
