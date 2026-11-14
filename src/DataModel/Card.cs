namespace DataModel;

public class Card
{
    public int Id { get; set; }

    // This is Id in the source.
    public int CardId { get; set; }
    public int KeyInId { get; set; }
    public int PaperIndex { get; set; }
    public int OriginalId { get; set; }
    public Original Original { get; set; }
    public ICollection<CardContest> CardContests { get; set; }
    public ICollection<OutstackCondition> OutstackConditions { get; set; }
}
