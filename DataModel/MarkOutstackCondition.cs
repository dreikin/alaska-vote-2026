namespace DataModel;

public class MarkOutstackCondition
{
    public int MarkId { get; set; }
    public Mark Mark { get; set; }
    public int OutstackConditionId { get; set; }
    public OutstackCondition OutstackCondition { get; set; }
}