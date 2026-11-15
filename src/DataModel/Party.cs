using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Party
{
    [Key] public required int Id { get; set; }

    public required string Description { get; set; }
    public string? ExternalId { get; set; }
    public ICollection<Candidate>? CandidateAffiliations { get; set; }
    public ICollection<Mark>? Marks { get; set; }
}
