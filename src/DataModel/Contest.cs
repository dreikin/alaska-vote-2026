using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Contest
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public string? ExternalId { get; set; }
    [Required] public required int DistrictId { get; set; }
    public District? District { get; set; }

    // (Presumably) How many people can win a contest.  Usually 1.
    [Required] public required int VoteFor { get; set; }

    // (Presumably) How many ranks a voter can use for RCV in the contest.
    [Required] public required int NumOfRanks { get; set; }

    // (Presumably) How many names can be written-in by a voter.
    [Required] public required int NumOfWriteins { get; set; }
    [Required] public required bool Disabled { get; set; }
    [Required] public required int ContestTypeId { get; set; }
    public ContestType? ContestType { get; set; }
    public ICollection<BallotType>? BallotTypes { get; set; }
    public ICollection<Candidate>? Candidates { get; set; }
    public ICollection<CardContest>? CardContests { get; set; }
}
