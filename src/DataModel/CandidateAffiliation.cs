namespace DataModel;

public class CandidateAffiliation
{
    public required int CandidateId { get; set; }
    public Candidate? Candidate { get; set; }
    public required int PartyId { get; set; }
    public Party? Party { get; set; }

    public CandidateAffiliation ShallowCopy()
    {
        return (CandidateAffiliation)MemberwiseClone();
    }
}

public class CandidateAffiliationValueEqualityComparer : IEqualityComparer<CandidateAffiliation>
{
    public bool Equals(CandidateAffiliation? x, CandidateAffiliation? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.CandidateId == y.CandidateId && x.PartyId == y.PartyId;
    }

    public int GetHashCode(CandidateAffiliation obj)
    {
        return HashCode.Combine(obj.CandidateId, obj.PartyId);
    }
}
