namespace DataModel;

public class Original
{
    public int Id { get; set; }
    public int PrecinctPortionId { get; set; }
    public PrecinctPortion PrecinctPortion { get; set; }
    public int BallotTypeId { get; set; }
    public BallotType BallotType { get; set; }
    public bool IsCurrent { get; set; }
    public int SessionId { get; set; }
    public Session Session { get; set; }
    public ICollection<Card> Cards { get; set; }
}
