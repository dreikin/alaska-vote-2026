namespace DataModel;

public class CandidateAffiliation
{
    public int CandidateId { get; set; }
    public Candidate Candidate { get; set; }
    public int AffiliationId { get; set; }
    // TODO: type is unknown
    public object Affiliation { get; set; }
}
