using System.Diagnostics.CodeAnalysis;
using Tests.Common;

namespace DataModel.Tests;

internal class DerivedContestFilter : ContestFilter
{
    [SetsRequiredMembers]
    public DerivedContestFilter(ContestFilter contestFilter)
    {
        Id = contestFilter.Id;
        ConfigurationId = contestFilter.ConfigurationId;
        Configuration = contestFilter.Configuration;
    }
}

public class ContestFilterValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        ContestFilter? a = null;
        ContestFilter? b = null;
        var comparer = new DataModel.ContestFilterValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.ContestFilter;
        var comparer = new DataModel.ContestFilterValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.ContestFilter;
        var b = Mocks.ContestFilter;
        var comparer = new DataModel.ContestFilterValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        ContestFilter? a = null;
        var b = Mocks.ContestFilter;
        var comparer = new DataModel.ContestFilterValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.ContestFilter;
        ContestFilter? b = null;
        var comparer = new DataModel.ContestFilterValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        ContestFilter a = new DerivedContestFilter(Mocks.ContestFilter);
        var b = Mocks.ContestFilter;
        var comparer = new DataModel.ContestFilterValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.ContestFilter;
        var b = Mocks.ContestFilter;
        b.Id += 1;
        var comparer = new DataModel.ContestFilterValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ConfigurationIdIsDifferent()
    {
        var a = Mocks.ContestFilter;
        var b = Mocks.ContestFilter;
        b.ConfigurationId += 1;
        var comparer = new DataModel.ContestFilterValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.ContestFilter;
        var b = Mocks.ContestFilter;
        b.Configuration = Mocks.Configuration;
        var comparer = new DataModel.ContestFilterValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}