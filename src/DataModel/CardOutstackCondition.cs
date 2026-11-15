namespace DataModel;

public class CardOutstackCondition
{
    public required int CardId { get; set; }
    public Card? Card { get; set; }
    public required int OutstackConditionId { get; set; }
    public OutstackCondition? OutstackCondition { get; set; }
}
