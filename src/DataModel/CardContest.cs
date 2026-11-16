using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class CardContest
{
    [Key] public int Id { get; set; }
    [Required] public required int ManifestationId { get; set; }
    [Required] public required int CardId { get; set; }
    public Card? Card { get; set; }
    [Required] public required int ContestId { get; set; } // Id
    public Contest? Contest { get; set; }
    [Required] public required int Undervotes { get; set; }
    [Required] public required int Overvotes { get; set; }
    public ICollection<OutstackCondition>? OutstackConditions { get; set; }
    public ICollection<Mark>? Marks { get; set; }

    public CardContest ShallowCopy()
    {
        return (CardContest)MemberwiseClone();
    }
}
