using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class CandidateType
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public ICollection<Candidate>? Candidates { get; set; }
}
