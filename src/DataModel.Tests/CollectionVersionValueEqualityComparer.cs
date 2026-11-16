using System.Diagnostics.CodeAnalysis;
using DataModel.Constants;
using Tests.Common;

namespace DataModel.Tests;

internal class DerivedCollectionVersion : CollectionVersion
{
    [SetsRequiredMembers]
    public DerivedCollectionVersion(CollectionVersion collectionVersion)
    {
        Id = collectionVersion.Id;
        Name = collectionVersion.Name;
        Version = collectionVersion.Version;
    }
}

public class CollectionVersionValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        CollectionVersion? a = null;
        CollectionVersion? b = null;
        var comparer = new DataModel.CollectionVersionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.CollectionVersion;
        var comparer = new DataModel.CollectionVersionValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.CollectionVersion;
        var b = Mocks.CollectionVersion;
        var comparer = new DataModel.CollectionVersionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        CollectionVersion? a = null;
        var b = Mocks.CollectionVersion;
        var comparer = new DataModel.CollectionVersionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.CollectionVersion;
        CollectionVersion? b = null;
        var comparer = new DataModel.CollectionVersionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        CollectionVersion a = new DerivedCollectionVersion(Mocks.CollectionVersion);
        var b = Mocks.CollectionVersion;
        var comparer = new DataModel.CollectionVersionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.CollectionVersion;
        var b = Mocks.CollectionVersion;
        b.Id += 1;
        var comparer = new DataModel.CollectionVersionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_NameIsDifferent()
    {
        var a = Mocks.CollectionVersion;
        var b = Mocks.CollectionVersion;
        b.Name = CollectionNames.Card;
        var comparer = new DataModel.CollectionVersionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_VersionIsDifferent()
    {
        var a = Mocks.CollectionVersion;
        var b = Mocks.CollectionVersion;
        b.Version = "1.0.0.1";
        var comparer = new DataModel.CollectionVersionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    [Skip("No reference fields on CollectionVersion yet.")]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.CollectionVersion;
        var b = Mocks.CollectionVersion;
        var comparer = new DataModel.CollectionVersionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}