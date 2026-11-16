using System.Diagnostics.CodeAnalysis;

namespace DataModel.Tests;

internal class DerivedVotingLocation : VotingLocation
{
    [SetsRequiredMembers]
    public DerivedVotingLocation(VotingLocation votingLocation)
    {
        Id = votingLocation.Id;
        Description = votingLocation.Description;
        Tabulators = votingLocation.Tabulators;
    }
}

public class VotingLocationValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        VotingLocation? a = null;
        VotingLocation? b = null;
        var comparer = new DataModel.VotingLocationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.VotingLocation;
        var comparer = new DataModel.VotingLocationValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.VotingLocation;
        var b = Mocks.VotingLocation;
        var comparer = new DataModel.VotingLocationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        VotingLocation? a = null;
        var b = Mocks.VotingLocation;
        var comparer = new DataModel.VotingLocationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.VotingLocation;
        VotingLocation? b = null;
        var comparer = new DataModel.VotingLocationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        VotingLocation a = new DerivedVotingLocation(Mocks.VotingLocation);
        var b = Mocks.VotingLocation;
        var comparer = new DataModel.VotingLocationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.VotingLocation;
        var b = Mocks.VotingLocation;
        b.Id += 1;
        var comparer = new DataModel.VotingLocationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DescriptionIsDifferent()
    {
        var a = Mocks.VotingLocation;
        var b = Mocks.VotingLocation;
        b.Description = "Carnival Ride";
        var comparer = new DataModel.VotingLocationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.VotingLocation;
        var b = Mocks.VotingLocation;
        b.Tabulators = new List<Tabulator>([Mocks.Tabulator]);
        var comparer = new DataModel.VotingLocationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
