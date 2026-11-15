using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Mark
{
    [Key] public int Id { get; set; }
    [Required] public required int ManifestationId { get; set; }
    [Required] public required int CardContestId { get; set; }
    public CardContest? CardContest { get; set; }
    [Required] public required int CandidateId { get; set; }
    public Candidate? Candidate { get; set; }
    [Required] public required int PartyId { get; set; }
    public Party? Party { get; set; }
    [Required] public required int Rank { get; set; }
    [Required] public required int MarkDensity { get; set; }
    [Required] public required bool IsAmbiguous { get; set; }
    [Required] public required bool IsVote { get; set; }
    public ICollection<OutstackCondition>? OutstackConditions { get; set; }
}
