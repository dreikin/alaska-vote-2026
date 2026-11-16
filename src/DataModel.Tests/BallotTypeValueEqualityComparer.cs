using System.Diagnostics.CodeAnalysis;

namespace DataModel.Tests;

internal class DerivedBallotType : BallotType
{
    [SetsRequiredMembers]
    public DerivedBallotType(BallotType ballotType)
    {
        Id = ballotType.Id;
        Description = ballotType.Description;
        ExternalId = ballotType.ExternalId;
        Contests = ballotType.Contests;
        Originals = ballotType.Originals;
    }
}

public class BallotTypeValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        BallotType? a = null;
        BallotType? b = null;
        var comparer = new DataModel.BallotTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        BallotType a = new() { Id = 1, Description = "Type 1" };
        var comparer = new DataModel.BallotTypeValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.BallotType;
        var b = Mocks.BallotType;
        var comparer = new DataModel.BallotTypeValueEqualityComparer();

        var result = Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        BallotType? a = null;
        var b = Mocks.BallotType;
        var comparer = new DataModel.BallotTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.BallotType;
        ;
        BallotType? b = null;
        var comparer = new DataModel.BallotTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        BallotType a = new DerivedBallotType(Mocks.BallotType);
        var b = Mocks.BallotType;
        var comparer = new DataModel.BallotTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.BallotType;
        var b = Mocks.BallotType;
        b.Id += 1;
        var comparer = new DataModel.BallotTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DescriptionIsDifferent()
    {
        var a = Mocks.BallotType;
        var b = Mocks.BallotType;
        b.Description = "Type 2";
        var comparer = new DataModel.BallotTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ExternalIdIsDifferent()
    {
        var a = Mocks.BallotType;
        var b = Mocks.BallotType;
        b.ExternalId = "SwingingChad";
        var comparer = new DataModel.BallotTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.BallotType;
        var b = Mocks.BallotType;
        b.Contests = new List<Contest>([Mocks.Contest]);
        b.Originals = new List<Original>([Mocks.Original]);
        var comparer = new DataModel.BallotTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
