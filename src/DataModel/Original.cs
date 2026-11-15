using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Original
{
    [Key] public int Id { get; set; }
    [Required] public required int PrecinctPortionId { get; set; }
    public PrecinctPortion? PrecinctPortion { get; set; }
    [Required] public required int BallotTypeId { get; set; }
    public BallotType? BallotType { get; set; }
    [Required] public required bool IsCurrent { get; set; }
    [Required] public required int SessionId { get; set; }
    public Session? Session { get; set; }
    public ICollection<Card>? Cards { get; set; }
}
