namespace DataModel;

public class DistrictPrecinctPortion
{
    public int DistrictId { get; set; }
    public District District { get; set; }
    public int PrecinctPortionId { get; set; }
    public PrecinctPortion PrecinctPortion { get; set; }
}
