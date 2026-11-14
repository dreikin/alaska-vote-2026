namespace DataModel;

public class CandidateAffiliation
{
    public int CandidateId { get; set; }
    public Candidate Candidate { get; set; }
    public int PartyId { get; set; }
    public Party Party { get; set; }
}
