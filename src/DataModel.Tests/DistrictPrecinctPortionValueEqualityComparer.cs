using System.Diagnostics.CodeAnalysis;
using Tests.Common;

namespace DataModel.Tests;

internal class DerivedDistrictPrecinctPortion : DistrictPrecinctPortion
{
    [SetsRequiredMembers]
    public DerivedDistrictPrecinctPortion(DistrictPrecinctPortion districtPrecinctPortion)
    {
        DistrictId = districtPrecinctPortion.DistrictId;
        District = districtPrecinctPortion.District;
        PrecinctPortionId = districtPrecinctPortion.PrecinctPortionId;
        PrecinctPortion = districtPrecinctPortion.PrecinctPortion;
    }
}

public class DistrictPrecinctPortionValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        DistrictPrecinctPortion? a = null;
        DistrictPrecinctPortion? b = null;
        var comparer = new DataModel.DistrictPrecinctPortionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.DistrictPrecinctPortion;
        var comparer = new DataModel.DistrictPrecinctPortionValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.DistrictPrecinctPortion;
        var b = Mocks.DistrictPrecinctPortion;
        var comparer = new DataModel.DistrictPrecinctPortionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        DistrictPrecinctPortion? a = null;
        var b = Mocks.DistrictPrecinctPortion;
        var comparer = new DataModel.DistrictPrecinctPortionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.DistrictPrecinctPortion;
        DistrictPrecinctPortion? b = null;
        var comparer = new DataModel.DistrictPrecinctPortionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        DistrictPrecinctPortion a = new DerivedDistrictPrecinctPortion(Mocks.DistrictPrecinctPortion);
        var b = Mocks.DistrictPrecinctPortion;
        var comparer = new DataModel.DistrictPrecinctPortionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DistrictIdIsDifferent()
    {
        var a = Mocks.DistrictPrecinctPortion;
        var b = Mocks.DistrictPrecinctPortion;
        b.DistrictId += 1;
        var comparer = new DataModel.DistrictPrecinctPortionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_PrecinctPortionIdIsDifferent()
    {
        var a = Mocks.DistrictPrecinctPortion;
        var b = Mocks.DistrictPrecinctPortion;
        b.PrecinctPortionId += 1;
        var comparer = new DataModel.DistrictPrecinctPortionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.DistrictPrecinctPortion;
        var b = Mocks.DistrictPrecinctPortion;
        b.District = Mocks.District;
        b.PrecinctPortion = Mocks.PrecinctPortion;
        var comparer = new DataModel.DistrictPrecinctPortionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}