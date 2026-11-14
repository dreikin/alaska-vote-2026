namespace DataModel;

public class Mark
{
    public int Id { get; set; }
    public int ManifestationId { get; set; }
    public int CardContestId { get; set; }
    public CardContest CardContest { get; set; }
    public int CandidateId { get; set; }
    public Candidate Candidate { get; set; }
    public int PartyId { get; set; }
    public Party Party { get; set; }
    public int Rank { get; set; }
    public int MarkDensity { get; set; }
    public bool IsAmbiguous { get; set; }
    public bool IsVote { get; set; }
    public ICollection<MarkOutstackCondition> MarkOutstackConditions { get; set; }
}
