using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Candidate
{
    [Key] public required int Id { get; set; }

    public required string Description { get; set; }
    public string? ExternalId { get; set; }
    public required int ContestId { get; set; }
    public Contest? Contest { get; set; }
    public required int CandidateTypeId { get; set; }
    public CandidateType? CandidateType { get; set; }
    public required bool Disabled { get; set; }
    public ICollection<Mark>? Marks { get; set; }
    public ICollection<Party>? PartyAffiliations { get; set; }
}
