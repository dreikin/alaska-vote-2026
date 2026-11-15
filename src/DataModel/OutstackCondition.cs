using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class OutstackCondition
{
    [Key] public int Id { get; set; }
    [Required] public required string Description { get; set; }
    public ICollection<CardContest>? CardContests { get; set; }
    public ICollection<Card>? Cards { get; set; }
    public ICollection<Configuration>? Configurations { get; set; }
    public ICollection<Mark>? Marks { get; set; }
}
