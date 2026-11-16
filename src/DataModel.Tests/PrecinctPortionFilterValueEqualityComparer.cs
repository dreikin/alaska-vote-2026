using System.Diagnostics.CodeAnalysis;
using Tests.Common;

namespace DataModel.Tests;

internal class DerivedPrecinctPortionFilter : PrecinctPortionFilter
{
    [SetsRequiredMembers]
    public DerivedPrecinctPortionFilter(PrecinctPortionFilter precinctPortionFilter)
    {
        Id = precinctPortionFilter.Id;
        ConfigurationId = precinctPortionFilter.ConfigurationId;
        Configuration = precinctPortionFilter.Configuration;
    }
}

public class PrecinctPortionFilterValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        PrecinctPortionFilter? a = null;
        PrecinctPortionFilter? b = null;
        var comparer = new DataModel.PrecinctPortionFilterValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.PrecinctPortionFilter;
        var comparer = new DataModel.PrecinctPortionFilterValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.PrecinctPortionFilter;
        var b = Mocks.PrecinctPortionFilter;
        var comparer = new DataModel.PrecinctPortionFilterValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        PrecinctPortionFilter? a = null;
        var b = Mocks.PrecinctPortionFilter;
        var comparer = new DataModel.PrecinctPortionFilterValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.PrecinctPortionFilter;
        PrecinctPortionFilter? b = null;
        var comparer = new DataModel.PrecinctPortionFilterValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        PrecinctPortionFilter a = new DerivedPrecinctPortionFilter(Mocks.PrecinctPortionFilter);
        var b = Mocks.PrecinctPortionFilter;
        var comparer = new DataModel.PrecinctPortionFilterValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.PrecinctPortionFilter;
        var b = Mocks.PrecinctPortionFilter;
        b.Id += 1;
        var comparer = new DataModel.PrecinctPortionFilterValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ConfigurationIdIsDifferent()
    {
        var a = Mocks.PrecinctPortionFilter;
        var b = Mocks.PrecinctPortionFilter;
        b.ConfigurationId += 1;
        var comparer = new DataModel.PrecinctPortionFilterValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.PrecinctPortionFilter;
        var b = Mocks.PrecinctPortionFilter;
        b.Configuration = Mocks.Configuration;
        var comparer = new DataModel.PrecinctPortionFilterValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
