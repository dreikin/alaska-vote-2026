namespace DataModel.Tests;

internal class DerivedBallotType : BallotType
{
}

public class BallotTypeEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        BallotType? a = null;
        BallotType? b = null;
        var comparer = new DataModel.BallotTypeEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        BallotType a = new() { Id = 1, Description = "Type 1" };
        var comparer = new DataModel.BallotTypeEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        BallotType a = new() { Id = 1, Description = "Type 1", ExternalId = "HangingChad" };
        BallotType b = new() { Id = 1, Description = "Type 1", ExternalId = "HangingChad" };
        var comparer = new DataModel.BallotTypeEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        BallotType? a = null;
        BallotType b = new() { Id = 1, Description = "Type 1", ExternalId = "HangingChad" };
        var comparer = new DataModel.BallotTypeEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        BallotType a = new() { Id = 1, Description = "Type 1", ExternalId = "HangingChad" };
        ;
        BallotType? b = null;
        var comparer = new DataModel.BallotTypeEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        BallotType a = new DerivedBallotType { Id = 1, Description = "Type 1", ExternalId = "HangingChad" };
        BallotType b = new() { Id = 1, Description = "Type 1", ExternalId = "HangingChad" };
        var comparer = new DataModel.BallotTypeEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        BallotType a = new() { Id = 1, Description = "Type 1", ExternalId = "HangingChad" };
        BallotType b = new() { Id = 2, Description = "Type 1", ExternalId = "HangingChad" };
        var comparer = new DataModel.BallotTypeEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DescriptionIsDifferent()
    {
        BallotType a = new() { Id = 1, Description = "Type 1", ExternalId = "HangingChad" };
        BallotType b = new() { Id = 1, Description = "Type 2", ExternalId = "HangingChad" };
        var comparer = new DataModel.BallotTypeEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ExternalIdIsDifferent()
    {
        BallotType a = new() { Id = 1, Description = "Type 1", ExternalId = "HangingChad" };
        BallotType b = new() { Id = 1, Description = "Type 2", ExternalId = "" };
        var comparer = new DataModel.BallotTypeEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var contest = new Contest
        {
            Id = 1,
            Description = "Governor",
            DistrictId = 0,
            VoteFor = 0,
            NumOfRanks = 0,
            NumOfWriteins = 0,
            Disabled = false,
            ContestTypeId = 0
        };
        var original = new Original
        {
            PrecinctPortionId = 0,
            BallotTypeId = 0,
            IsCurrent = false,
            SessionId = 0
        };
        ICollection<Contest> contests = new List<Contest>([contest]);
        ICollection<Original> originals = new List<Original>([original]);
        BallotType a = new()
            { Id = 1, Description = "Type 1", ExternalId = "HangingChad", Contests = contests, Originals = originals };
        BallotType b = new() { Id = 1, Description = "Type 1", ExternalId = "HangingChad" };
        var comparer = new DataModel.BallotTypeEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
