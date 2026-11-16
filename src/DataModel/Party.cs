using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Party
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public string? ExternalId { get; set; }
    public ICollection<Candidate>? CandidateAffiliations { get; set; }
    public ICollection<Mark>? Marks { get; set; }

    public Party ShallowCopy()
    {
        return (Party)MemberwiseClone();
    }
}
