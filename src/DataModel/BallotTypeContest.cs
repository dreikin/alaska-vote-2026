namespace DataModel;

public class BallotTypeContest
{
    public required int BallotTypeId { get; set; }
    public BallotType? BallotType { get; set; }
    public required int ContestId { get; set; }
    public Contest? Contest { get; set; }
}
