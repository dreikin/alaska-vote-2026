namespace DataModel;

public class CandidateType
{
    public int Id { get; set; }
    public string Description { get; set; }
    public ICollection<Candidate> Candidates { get; set; }
}
