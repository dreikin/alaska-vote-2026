using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Card
{
    [Key] public int Id { get; set; }

    // This is Id in the source.
    // TODO: Make sure this doesn't create a shadow property for the key.
    [Required] public required int CardId { get; set; }
    [Required] public required int KeyInId { get; set; }
    [Required] public required int PaperIndex { get; set; }
    [Required] public required int OriginalId { get; set; }
    public Original? Original { get; set; }
    public ICollection<CardContest>? CardContests { get; set; }
    public ICollection<OutstackCondition>? OutstackConditions { get; set; }
}
