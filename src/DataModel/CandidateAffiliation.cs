namespace DataModel;

public class CandidateAffiliation
{
    public required int CandidateId { get; set; }
    public Candidate? Candidate { get; set; }
    public required int PartyId { get; set; }
    public Party? Party { get; set; }
}
