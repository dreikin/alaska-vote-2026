namespace DataModel;

public class Candidate
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string ExternalId { get; set; }
    public int ContestId { get; set; }
    public Contest Contest { get; set; }
    public int TypeId { get; set; }
    public CandidateType Type { get; set; }
    public bool Disabled { get; set; }
    public ICollection<CandidateAffiliation> Affiliations { get; set; }
}
