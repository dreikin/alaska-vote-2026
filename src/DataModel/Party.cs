namespace DataModel;

public class Party
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string ExternalId { get; set; }
    public ICollection<Candidate> CandidateAffiliations { get; set; }
}
