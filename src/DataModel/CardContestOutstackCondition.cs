namespace DataModel;

public class CardContestOutstackCondition
{
    public required int CardContestId { get; set; }
    public CardContest? CardContest { get; set; }
    public required int OutstackConditionId { get; set; }
    public OutstackCondition? OutstackCondition { get; set; }
}
