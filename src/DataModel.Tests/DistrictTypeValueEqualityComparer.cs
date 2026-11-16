using System.Diagnostics.CodeAnalysis;

namespace DataModel.Tests;

internal class DerivedDistrictType : DistrictType
{
    [SetsRequiredMembers]
    public DerivedDistrictType(DistrictType districtType)
    {
        Id = districtType.Id;
        Description = districtType.Description;
        ExternalId = districtType.ExternalId;
        Districts = districtType.Districts;
    }
}

public class DistrictTypeValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        DistrictType? a = null;
        DistrictType? b = null;
        var comparer = new DataModel.DistrictTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.DistrictType;
        var comparer = new DataModel.DistrictTypeValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.DistrictType;
        var b = Mocks.DistrictType;
        var comparer = new DataModel.DistrictTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        DistrictType? a = null;
        var b = Mocks.DistrictType;
        var comparer = new DataModel.DistrictTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.DistrictType;
        DistrictType? b = null;
        var comparer = new DataModel.DistrictTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        DistrictType a = new DerivedDistrictType(Mocks.DistrictType);
        var b = Mocks.DistrictType;
        var comparer = new DataModel.DistrictTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.DistrictType;
        var b = Mocks.DistrictType;
        b.Id = Guid.NewGuid();
        var comparer = new DataModel.DistrictTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DescriptionIsDifferent()
    {
        var a = Mocks.DistrictType;
        var b = Mocks.DistrictType;
        b.Description = "Underwhelming";
        var comparer = new DataModel.DistrictTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ExternalIdIsDifferent()
    {
        var a = Mocks.DistrictType;
        var b = Mocks.DistrictType;
        b.Description = "Abandoned";
        var comparer = new DataModel.DistrictTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.DistrictType;
        var b = Mocks.DistrictType;
        b.Districts = new List<District>([Mocks.District]);
        var comparer = new DataModel.DistrictTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
