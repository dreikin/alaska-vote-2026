using System.Diagnostics.CodeAnalysis;

namespace DataModel.Tests;

internal class DerivedDistrict : District
{
    [SetsRequiredMembers]
    public DerivedDistrict(District district)
    {
        Id = district.Id;
        Description = district.Description;
        ExternalId = district.ExternalId;
        DistrictTypeId = district.DistrictTypeId;
        DistrictType = district.DistrictType;
        Contests = district.Contests;
        PrecinctPortions = district.PrecinctPortions;
    }
}

public class DistrictValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        District? a = null;
        District? b = null;
        var comparer = new DataModel.DistrictValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.District;
        var comparer = new DataModel.DistrictValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.District;
        var b = Mocks.District;
        var comparer = new DataModel.DistrictValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        District? a = null;
        var b = Mocks.District;
        var comparer = new DataModel.DistrictValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.District;
        District? b = null;
        var comparer = new DataModel.DistrictValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        District a = new DerivedDistrict(Mocks.District);
        var b = Mocks.District;
        var comparer = new DataModel.DistrictValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.District;
        var b = Mocks.District;
        b.Id += 1;
        var comparer = new DataModel.DistrictValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DescriptionIsDifferent()
    {
        var a = Mocks.District;
        var b = Mocks.District;
        b.Description = "District 42";
        var comparer = new DataModel.DistrictValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ExternalIdIsDifferent()
    {
        var a = Mocks.District;
        var b = Mocks.District;
        b.Description = "The Answer";
        var comparer = new DataModel.DistrictValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DistrictTypeIdIsDifferent()
    {
        var a = Mocks.District;
        var b = Mocks.District;
        b.DistrictTypeId = Guid.NewGuid();
        var comparer = new DataModel.DistrictValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.District;
        var b = Mocks.District;
        b.DistrictType = Mocks.DistrictType;
        b.Contests = new List<Contest>([Mocks.Contest]);
        b.PrecinctPortions = new List<PrecinctPortion>([Mocks.PrecinctPortion]);
        var comparer = new DataModel.DistrictValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
