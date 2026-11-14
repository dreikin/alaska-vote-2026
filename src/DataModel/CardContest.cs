namespace DataModel;

public class CardContest
{
    public int Id { get; set; }
    public int ManifestationId { get; set; }
    public int CardId { get; set; }
    public Card Card { get; set; }
    public int ContestId { get; set; } // Id
    public Contest Contest { get; set; }
    public int Undervotes { get; set; }
    public int Overvotes { get; set; }
    public ICollection<CardContestOutstackCondition> CardContestOutstackConditions { get; set; }
    public ICollection<Mark> Marks { get; set; }
}
