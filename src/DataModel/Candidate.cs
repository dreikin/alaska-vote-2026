using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Candidate
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public string? ExternalId { get; set; }
    [Required] public required int ContestId { get; set; }
    public Contest? Contest { get; set; }
    [Required] public required int CandidateTypeId { get; set; }
    [Required] public CandidateType? CandidateType { get; set; }
    [Required] public required bool Disabled { get; set; }
    public ICollection<Mark>? Marks { get; set; }
    public ICollection<Party>? PartyAffiliations { get; set; }
}
