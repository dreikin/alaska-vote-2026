using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class CardContest
{
    [Key] public required int Id { get; set; }

    public required int ManifestationId { get; set; }
    public required int CardId { get; set; }
    public Card? Card { get; set; }
    public required int ContestId { get; set; } // Id
    public Contest? Contest { get; set; }
    public required int Undervotes { get; set; }
    public required int Overvotes { get; set; }
    public ICollection<OutstackCondition>? OutstackConditions { get; set; }
    public ICollection<Mark>? Marks { get; set; }
}
