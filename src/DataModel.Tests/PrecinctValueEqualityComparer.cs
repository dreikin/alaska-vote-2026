using System.Diagnostics.CodeAnalysis;

namespace DataModel.Tests;

internal class DerivedPrecinct : Precinct
{
    [SetsRequiredMembers]
    public DerivedPrecinct(Precinct precinct)
    {
        Id = precinct.Id;
        Description = precinct.Description;
        ExternalId = precinct.ExternalId;
        PrecinctPortions = precinct.PrecinctPortions;
    }
}

public class PrecinctValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        Precinct? a = null;
        Precinct? b = null;
        var comparer = new DataModel.PrecinctValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.Precinct;
        var comparer = new DataModel.PrecinctValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.Precinct;
        var b = Mocks.Precinct;
        var comparer = new DataModel.PrecinctValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        Precinct? a = null;
        var b = Mocks.Precinct;
        var comparer = new DataModel.PrecinctValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.Precinct;
        Precinct? b = null;
        var comparer = new DataModel.PrecinctValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        Precinct a = new DerivedPrecinct(Mocks.Precinct);
        var b = Mocks.Precinct;
        var comparer = new DataModel.PrecinctValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.Precinct;
        var b = Mocks.Precinct;
        b.Id += 1;
        var comparer = new DataModel.PrecinctValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DescriptionIsDifferent()
    {
        var a = Mocks.Precinct;
        var b = Mocks.Precinct;
        b.Description = "Postcinct";
        var comparer = new DataModel.PrecinctValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ExternalIdIsDifferent()
    {
        var a = Mocks.Precinct;
        var b = Mocks.Precinct;
        b.ExternalId = "Outer Precincts #12";
        var comparer = new DataModel.PrecinctValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.Precinct;
        var b = Mocks.Precinct;
        b.PrecinctPortions = new List<PrecinctPortion>([Mocks.PrecinctPortion]);
        var comparer = new DataModel.PrecinctValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
