using System.Diagnostics.CodeAnalysis;

namespace DataModel.Tests;

internal class DerivedContestType : ContestType
{
    [SetsRequiredMembers]
    public DerivedContestType(ContestType contestType)
    {
        Id = contestType.Id;
        Description = contestType.Description;
        Contests = contestType.Contests;
    }
}

public class ContestTypeValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        ContestType? a = null;
        ContestType? b = null;
        var comparer = new DataModel.ContestTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.ContestType;
        var comparer = new DataModel.ContestTypeValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.ContestType;
        var b = Mocks.ContestType;
        var comparer = new DataModel.ContestTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        ContestType? a = null;
        var b = Mocks.ContestType;
        var comparer = new DataModel.ContestTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.ContestType;
        ContestType? b = null;
        var comparer = new DataModel.ContestTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        ContestType a = new DerivedContestType(Mocks.ContestType);
        var b = Mocks.ContestType;
        var comparer = new DataModel.ContestTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.ContestType;
        var b = Mocks.ContestType;
        b.Id += 1;
        var comparer = new DataModel.ContestTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DescriptionIsDifferent()
    {
        var a = Mocks.ContestType;
        var b = Mocks.ContestType;
        b.Description = "Competitive";
        var comparer = new DataModel.ContestTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.ContestType;
        var b = Mocks.ContestType;
        b.Contests = new List<Contest>([Mocks.Contest]);
        var comparer = new DataModel.ContestTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
