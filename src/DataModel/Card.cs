namespace DataModel;

public class Card
{
    public int Id { get; set; }
    public int KeyInId { get; set; }
    public int PaperIndex { get; set; }
    public ICollection<CardContest> CardContests { get; set; }
    public ICollection<CardOutstackCondition> CardOutstackConditions { get; set; }
}
