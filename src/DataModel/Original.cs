using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Original
{
    [Key] public required int Id { get; set; }
    public required int PrecinctPortionId { get; set; }
    public PrecinctPortion? PrecinctPortion { get; set; }
    public required int BallotTypeId { get; set; }
    public BallotType? BallotType { get; set; }
    public required bool IsCurrent { get; set; }
    public required int SessionId { get; set; }
    public Session? Session { get; set; }
    public ICollection<Card>? Cards { get; set; }
}
