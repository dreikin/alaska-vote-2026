namespace DataModel;

public class CardContestOutstackCondition
{
    public int CardContestId { get; set; }
    public CardContest CardContest { get; set; }
    public int OutstackConditionId { get; set; }
    public OutstackCondition OutstackCondition { get; set; }
}
