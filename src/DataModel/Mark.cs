using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Mark
{
    [Key] public required int Id { get; set; }

    public required int ManifestationId { get; set; }
    public required int CardContestId { get; set; }
    public CardContest? CardContest { get; set; }
    public required int CandidateId { get; set; }
    public Candidate? Candidate { get; set; }
    public required int PartyId { get; set; }
    public Party? Party { get; set; }
    public required int Rank { get; set; }
    public required int MarkDensity { get; set; }
    public required bool IsAmbiguous { get; set; }
    public required bool IsVote { get; set; }
    public ICollection<OutstackCondition>? OutstackConditions { get; set; }
}
