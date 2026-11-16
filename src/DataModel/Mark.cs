using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Mark
{
    [Key] public int Id { get; set; }
    [Required] public required int ManifestationId { get; set; }
    [Required] public required int CardContestId { get; set; }
    public CardContest? CardContest { get; set; }
    [Required] public required int CandidateId { get; set; }
    public Candidate? Candidate { get; set; }
    [Required] public required int PartyId { get; set; }
    public Party? Party { get; set; }
    [Required] public required int Rank { get; set; }
    [Required] public required int MarkDensity { get; set; }
    [Required] public required bool IsAmbiguous { get; set; }
    [Required] public required bool IsVote { get; set; }
    public ICollection<OutstackCondition>? OutstackConditions { get; set; }

    public Mark ShallowCopy()
    {
        return (Mark)MemberwiseClone();
    }
}

public class MarkValueEqualityComparer : IEqualityComparer<Mark>
{
    public bool Equals(Mark? x, Mark? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id && x.ManifestationId == y.ManifestationId && x.CardContestId == y.CardContestId &&
               x.CandidateId == y.CandidateId && x.PartyId == y.PartyId && x.Rank == y.Rank &&
               x.MarkDensity == y.MarkDensity && x.IsAmbiguous == y.IsAmbiguous && x.IsVote == y.IsVote;
    }

    public int GetHashCode(Mark obj)
    {
        var hashCode = new HashCode();
        hashCode.Add(obj.Id);
        hashCode.Add(obj.ManifestationId);
        hashCode.Add(obj.CardContestId);
        hashCode.Add(obj.CandidateId);
        hashCode.Add(obj.PartyId);
        hashCode.Add(obj.Rank);
        hashCode.Add(obj.MarkDensity);
        hashCode.Add(obj.IsAmbiguous);
        hashCode.Add(obj.IsVote);
        return hashCode.ToHashCode();
    }
}
