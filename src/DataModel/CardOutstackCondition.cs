namespace DataModel;

public class CardOutstackCondition
{
    public int CardId { get; set; }
    public Card Card { get; set; }
    public int OutstackConditionId { get; set; }
    public OutstackCondition OutstackCondition { get; set; }
}
