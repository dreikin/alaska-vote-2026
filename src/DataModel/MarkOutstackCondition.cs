namespace DataModel;

public class MarkOutstackCondition
{
    public required int MarkId { get; set; }
    public Mark? Mark { get; set; }
    public required int OutstackConditionId { get; set; }
    public OutstackCondition? OutstackCondition { get; set; }

    public MarkOutstackCondition ShallowCopy()
    {
        return (MarkOutstackCondition)MemberwiseClone();
    }
}
