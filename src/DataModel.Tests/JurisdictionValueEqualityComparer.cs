using System.Diagnostics.CodeAnalysis;

namespace DataModel.Tests;

internal class DerivedJurisdiction : Jurisdiction
{
    [SetsRequiredMembers]
    public DerivedJurisdiction(Jurisdiction jurisdiction)
    {
        Id = jurisdiction.Id;
        Description = jurisdiction.Description;
        ElectionEvents = jurisdiction.ElectionEvents;
    }
}

public class JurisdictionValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        Jurisdiction? a = null;
        Jurisdiction? b = null;
        var comparer = new DataModel.JurisdictionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.Jurisdiction;
        var comparer = new DataModel.JurisdictionValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.Jurisdiction;
        var b = Mocks.Jurisdiction;
        var comparer = new DataModel.JurisdictionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        Jurisdiction? a = null;
        var b = Mocks.Jurisdiction;
        var comparer = new DataModel.JurisdictionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.Jurisdiction;
        Jurisdiction? b = null;
        var comparer = new DataModel.JurisdictionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        Jurisdiction a = new DerivedJurisdiction(Mocks.Jurisdiction);
        var b = Mocks.Jurisdiction;
        var comparer = new DataModel.JurisdictionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.Jurisdiction;
        var b = Mocks.Jurisdiction;
        b.Id += 1;
        var comparer = new DataModel.JurisdictionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DescriptionIsDifferent()
    {
        var a = Mocks.Jurisdiction;
        var b = Mocks.Jurisdiction;
        b.Description = "National Forestry Service";
        var comparer = new DataModel.JurisdictionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.Jurisdiction;
        var b = Mocks.Jurisdiction;
        b.ElectionEvents = new List<ElectionEvent>([Mocks.ElectionEvent]);
        var comparer = new DataModel.JurisdictionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
