using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class PrecinctPortionFilter
{
    [Key] public required int Id { get; set; }

    public required int ConfigurationId { get; set; }
    public Configuration? Configuration { get; set; }
}
