using System.Diagnostics.CodeAnalysis;

namespace DataModel.Tests;

internal class DerivedTabulator : Tabulator
{
    [SetsRequiredMembers]
    public DerivedTabulator(Tabulator tabulator)
    {
        Id = tabulator.Id;
        Description = tabulator.Description;
        ExternalId = tabulator.ExternalId;
        VotingLocationId = tabulator.VotingLocationId;
        VotingLocation = tabulator.VotingLocation;
        TabulatorTypeId = tabulator.TabulatorTypeId;
        TabulatorType = tabulator.TabulatorType;
        ThresholdMin = tabulator.ThresholdMin;
        ThresholdMax = tabulator.ThresholdMax;
        WriteThresholdMin = tabulator.WriteThresholdMin;
        WriteThresholdMax = tabulator.WriteThresholdMax;
        Sessions = tabulator.Sessions;
    }
}

public class TabulatorValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        Tabulator? a = null;
        Tabulator? b = null;
        var comparer = new DataModel.TabulatorValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.Tabulator;
        var comparer = new DataModel.TabulatorValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.Tabulator;
        var b = Mocks.Tabulator;
        var comparer = new DataModel.TabulatorValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        Tabulator? a = null;
        var b = Mocks.Tabulator;
        var comparer = new DataModel.TabulatorValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.Tabulator;
        Tabulator? b = null;
        var comparer = new DataModel.TabulatorValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        Tabulator a = new DerivedTabulator(Mocks.Tabulator);
        var b = Mocks.Tabulator;
        var comparer = new DataModel.TabulatorValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.Tabulator;
        var b = Mocks.Tabulator;
        b.Id += 1;
        var comparer = new DataModel.TabulatorValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DescriptionIsDifferent()
    {
        var a = Mocks.Tabulator;
        var b = Mocks.Tabulator;
        b.Description = "John Hancock";
        var comparer = new DataModel.TabulatorValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ExternalIdIsDifferent()
    {
        var a = Mocks.Tabulator;
        var b = Mocks.Tabulator;
        b.ExternalId = "Big Sig";
        var comparer = new DataModel.TabulatorValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_VotingLocationIdIsDifferent()
    {
        var a = Mocks.Tabulator;
        var b = Mocks.Tabulator;
        b.VotingLocationId += 1;
        var comparer = new DataModel.TabulatorValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_TabulatorTypeIdIsDifferent()
    {
        var a = Mocks.Tabulator;
        var b = Mocks.Tabulator;
        b.TabulatorTypeId += 1;
        var comparer = new DataModel.TabulatorValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ThresholdMinIsDifferent()
    {
        var a = Mocks.Tabulator;
        var b = Mocks.Tabulator;
        b.ThresholdMin += 1;
        var comparer = new DataModel.TabulatorValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ThresholdMaxIsDifferent()
    {
        var a = Mocks.Tabulator;
        var b = Mocks.Tabulator;
        b.ThresholdMax += 1;
        var comparer = new DataModel.TabulatorValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_WriteThresholdMinIsDifferent()
    {
        var a = Mocks.Tabulator;
        var b = Mocks.Tabulator;
        b.WriteThresholdMin += 1;
        var comparer = new DataModel.TabulatorValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_WriteThresholdMaxIsDifferent()
    {
        var a = Mocks.Tabulator;
        var b = Mocks.Tabulator;
        b.WriteThresholdMax += 1;
        var comparer = new DataModel.TabulatorValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.Tabulator;
        var b = Mocks.Tabulator;
        b.VotingLocation = Mocks.VotingLocation;
        b.TabulatorType = Mocks.TabulatorType;
        b.Sessions = new List<Session>([Mocks.Session]);
        var comparer = new DataModel.TabulatorValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
