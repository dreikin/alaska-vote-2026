using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class ContestFilter
{
    [Key] public required int Id { get; set; }

    public required int ConfigurationId { get; set; }
    public Configuration? Configuration { get; set; }
}
