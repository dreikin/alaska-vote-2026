using System.Diagnostics.CodeAnalysis;
using Tests.Common;

namespace DataModel.Tests;

internal class DerivedTabulatorType : TabulatorType
{
    [SetsRequiredMembers]
    public DerivedTabulatorType(TabulatorType tabulatorType)
    {
        Id = tabulatorType.Id;
        Description = tabulatorType.Description;
        Tabulators = tabulatorType.Tabulators;
    }
}

public class TabulatorTypeValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        TabulatorType? a = null;
        TabulatorType? b = null;
        var comparer = new DataModel.TabulatorTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.TabulatorType;
        var comparer = new DataModel.TabulatorTypeValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.TabulatorType;
        var b = Mocks.TabulatorType;
        var comparer = new DataModel.TabulatorTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        TabulatorType? a = null;
        var b = Mocks.TabulatorType;
        var comparer = new DataModel.TabulatorTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.TabulatorType;
        TabulatorType? b = null;
        var comparer = new DataModel.TabulatorTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        TabulatorType a = new DerivedTabulatorType(Mocks.TabulatorType);
        var b = Mocks.TabulatorType;
        var comparer = new DataModel.TabulatorTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.TabulatorType;
        var b = Mocks.TabulatorType;
        b.Id += 1;
        var comparer = new DataModel.TabulatorTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DescriptionIsDifferent()
    {
        var a = Mocks.TabulatorType;
        var b = Mocks.TabulatorType;
        b.Description = "Manual";
        var comparer = new DataModel.TabulatorTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.TabulatorType;
        var b = Mocks.TabulatorType;
        b.Tabulators = new List<Tabulator>([Mocks.Tabulator]);
        var comparer = new DataModel.TabulatorTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
