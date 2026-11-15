using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Card
{
    [Key] public required int Id { get; set; }

    // This is Id in the source.
    // TODO: Make sure this doesn't create a shadow property for the key.
    public required int CardId { get; set; }
    public required int KeyInId { get; set; }
    public required int PaperIndex { get; set; }
    public required int OriginalId { get; set; }
    public Original? Original { get; set; }
    public ICollection<CardContest>? CardContests { get; set; }
    public ICollection<OutstackCondition>? OutstackConditions { get; set; }
}
