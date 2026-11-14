namespace DataModel;

public class BallotTypeContest
{
    public int BallotTypeId { get; set; }
    public BallotType BallotType { get; set; }
    public int ContestId { get; set; }
    public Contest Contest { get; set; }
}
