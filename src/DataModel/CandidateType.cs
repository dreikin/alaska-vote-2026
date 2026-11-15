using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class CandidateType
{
    [Key] public required int Id { get; set; }

    public required string Description { get; set; }
    public ICollection<Candidate>? Candidates { get; set; }
}
