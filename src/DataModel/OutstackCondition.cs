namespace DataModel;

public class OutstackCondition
{
    public int Id { get; set; }
    public string Description { get; set; }
    public ICollection<CardContest> CardContests { get; set; }
    public ICollection<Card> Cards { get; set; }
    public ICollection<Mark> Marks { get; set; }
}
