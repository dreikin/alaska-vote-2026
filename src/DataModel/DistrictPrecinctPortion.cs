namespace DataModel;

public class DistrictPrecinctPortion
{
    public required int DistrictId { get; set; }
    public District? District { get; set; }
    public required int PrecinctPortionId { get; set; }
    public PrecinctPortion? PrecinctPortion { get; set; }
}
