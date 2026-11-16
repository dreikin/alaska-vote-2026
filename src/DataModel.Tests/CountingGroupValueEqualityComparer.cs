using System.Diagnostics.CodeAnalysis;

namespace DataModel.Tests;

internal class DerivedCountingGroup : CountingGroup
{
    [SetsRequiredMembers]
    public DerivedCountingGroup(CountingGroup countingGroup)
    {
        Id = countingGroup.Id;
        Description = countingGroup.Description;
        ExternalId = countingGroup.ExternalId;
        Sessions = countingGroup.Sessions;
    }
}

public class CountingGroupValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        CountingGroup? a = null;
        CountingGroup? b = null;
        var comparer = new DataModel.CountingGroupValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.CountingGroup;
        var comparer = new DataModel.CountingGroupValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.CountingGroup;
        var b = Mocks.CountingGroup;
        var comparer = new DataModel.CountingGroupValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        CountingGroup? a = null;
        var b = Mocks.CountingGroup;
        var comparer = new DataModel.CountingGroupValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.CountingGroup;
        CountingGroup? b = null;
        var comparer = new DataModel.CountingGroupValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        CountingGroup a = new DerivedCountingGroup(Mocks.CountingGroup);
        var b = Mocks.CountingGroup;
        var comparer = new DataModel.CountingGroupValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.CountingGroup;
        var b = Mocks.CountingGroup;
        b.Id += 1;
        var comparer = new DataModel.CountingGroupValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DescriptionIsDifferent()
    {
        var a = Mocks.CountingGroup;
        var b = Mocks.CountingGroup;
        b.Description = "Slackers";
        var comparer = new DataModel.CountingGroupValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ExternalIdIsDifferent()
    {
        var a = Mocks.CountingGroup;
        var b = Mocks.CountingGroup;
        b.Description = "Cautious 2";
        var comparer = new DataModel.CountingGroupValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.CountingGroup;
        var b = Mocks.CountingGroup;
        b.Sessions = new List<Session>([Mocks.Session]);
        var comparer = new DataModel.CountingGroupValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
