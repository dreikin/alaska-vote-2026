using System.Diagnostics.CodeAnalysis;

namespace DataModel.Tests;

internal class DerivedPrecinctPortion : PrecinctPortion
{
    [SetsRequiredMembers]
    public DerivedPrecinctPortion(PrecinctPortion precinctPortion)
    {
        Id = precinctPortion.Id;
        Description = precinctPortion.Description;
        ExternalId = precinctPortion.ExternalId;
        PrecinctId = precinctPortion.PrecinctId;
        Precinct = precinctPortion.Precinct;
        Districts = precinctPortion.Districts;
        Originals = precinctPortion.Originals;
    }
}

public class PrecinctPortionValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        PrecinctPortion? a = null;
        PrecinctPortion? b = null;
        var comparer = new DataModel.PrecinctPortionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.PrecinctPortion;
        var comparer = new DataModel.PrecinctPortionValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.PrecinctPortion;
        var b = Mocks.PrecinctPortion;
        var comparer = new DataModel.PrecinctPortionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        PrecinctPortion? a = null;
        var b = Mocks.PrecinctPortion;
        var comparer = new DataModel.PrecinctPortionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.PrecinctPortion;
        PrecinctPortion? b = null;
        var comparer = new DataModel.PrecinctPortionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        PrecinctPortion a = new DerivedPrecinctPortion(Mocks.PrecinctPortion);
        var b = Mocks.PrecinctPortion;
        var comparer = new DataModel.PrecinctPortionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.PrecinctPortion;
        var b = Mocks.PrecinctPortion;
        b.Id += 1;
        var comparer = new DataModel.PrecinctPortionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DescriptionIsDifferent()
    {
        var a = Mocks.PrecinctPortion;
        var b = Mocks.PrecinctPortion;
        b.Description = "Tiny";
        var comparer = new DataModel.PrecinctPortionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ExternalIdIsDifferent()
    {
        var a = Mocks.PrecinctPortion;
        var b = Mocks.PrecinctPortion;
        b.ExternalId = "Outer PrecinctPortions #12 Segment #3";
        var comparer = new DataModel.PrecinctPortionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_PrecinctIdIsDifferent()
    {
        var a = Mocks.PrecinctPortion;
        var b = Mocks.PrecinctPortion;
        b.PrecinctId += 1;
        var comparer = new DataModel.PrecinctPortionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.PrecinctPortion;
        var b = Mocks.PrecinctPortion;
        b.Precinct = Mocks.Precinct;
        b.Districts = new List<District>([Mocks.District]);
        b.Originals = new List<Original>([Mocks.Original]);
        var comparer = new DataModel.PrecinctPortionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
