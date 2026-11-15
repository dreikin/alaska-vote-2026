using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class PrecinctPortionFilter
{
    [Key] public int Id { get; set; }
    [Required] public required int ConfigurationId { get; set; }
    public Configuration? Configuration { get; set; }
}
