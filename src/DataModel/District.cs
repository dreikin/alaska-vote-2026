namespace DataModel;

public class District
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string ExternalId { get; set; }
    public Guid DistrictTypeId { get; set; }
    public DistrictType DistrictType { get; set; }
    public ICollection<PrecinctPortion> PrecinctPortions { get; set; }
}
