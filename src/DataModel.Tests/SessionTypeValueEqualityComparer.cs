using System.Diagnostics.CodeAnalysis;
using Tests.Common;

namespace DataModel.Tests;

internal class DerivedSessionType : SessionType
{
    [SetsRequiredMembers]
    public DerivedSessionType(SessionType sessionType)
    {
        Id = sessionType.Id;
        Description = sessionType.Description;
        Sessions = sessionType.Sessions;
    }
}

public class SessionTypeValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        SessionType? a = null;
        SessionType? b = null;
        var comparer = new DataModel.SessionTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.SessionType;
        var comparer = new DataModel.SessionTypeValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.SessionType;
        var b = Mocks.SessionType;
        var comparer = new DataModel.SessionTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        SessionType? a = null;
        var b = Mocks.SessionType;
        var comparer = new DataModel.SessionTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.SessionType;
        SessionType? b = null;
        var comparer = new DataModel.SessionTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        SessionType a = new DerivedSessionType(Mocks.SessionType);
        var b = Mocks.SessionType;
        var comparer = new DataModel.SessionTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.SessionType;
        var b = Mocks.SessionType;
        b.Id += 1;
        var comparer = new DataModel.SessionTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DescriptionIsDifferent()
    {
        var a = Mocks.SessionType;
        var b = Mocks.SessionType;
        b.Description = "Extended";
        var comparer = new DataModel.SessionTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.SessionType;
        var b = Mocks.SessionType;
        b.Sessions = new List<Session>([Mocks.Session]);
        var comparer = new DataModel.SessionTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
