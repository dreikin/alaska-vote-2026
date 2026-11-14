namespace DataModel;

public class Contest
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string ExternalId  { get; set; }
    public int DistrictId { get; set; }
    public District District { get; set; }
    // (Presumably) How many people can win a contest.  Usually 1.
    public int VoteFor { get; set; }
    // (Presumably) How many ranks a voter can use for RCV in the contest.
    public int NumOfRanks { get; set; }
    // (Presumably) How many names can be written-in by a voter.
    public int NumOfWriteins { get; set; }
    public bool Disabled { get; set; }
    public int TypeId { get; set; }
    public ContestType Type { get; set; }
}
