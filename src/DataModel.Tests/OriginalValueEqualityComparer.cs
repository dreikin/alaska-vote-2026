using System.Diagnostics.CodeAnalysis;

namespace DataModel.Tests;

internal class DerivedOriginal : Original
{
    [SetsRequiredMembers]
    public DerivedOriginal(Original original)
    {
        Id = original.Id;
        PrecinctPortionId = original.PrecinctPortionId;
        PrecinctPortion = original.PrecinctPortion;
        BallotTypeId = original.BallotTypeId;
        BallotType = original.BallotType;
        IsCurrent = original.IsCurrent;
        SessionId = original.SessionId;
        Session = original.Session;
        Cards = original.Cards;
    }
}

public class OriginalValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        Original? a = null;
        Original? b = null;
        var comparer = new DataModel.OriginalValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.Original;
        var comparer = new DataModel.OriginalValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.Original;
        var b = Mocks.Original;
        var comparer = new DataModel.OriginalValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        Original? a = null;
        var b = Mocks.Original;
        var comparer = new DataModel.OriginalValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.Original;
        Original? b = null;
        var comparer = new DataModel.OriginalValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        Original a = new DerivedOriginal(Mocks.Original);
        var b = Mocks.Original;
        var comparer = new DataModel.OriginalValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.Original;
        var b = Mocks.Original;
        b.Id += 1;
        var comparer = new DataModel.OriginalValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_PrecinctPortionIdIsDifferent()
    {
        var a = Mocks.Original;
        var b = Mocks.Original;
        b.PrecinctPortionId += 1;
        var comparer = new DataModel.OriginalValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_BallotTypeIdIsDifferent()
    {
        var a = Mocks.Original;
        var b = Mocks.Original;
        b.BallotTypeId += 1;
        var comparer = new DataModel.OriginalValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IsCurrentIsDifferent()
    {
        var a = Mocks.Original;
        var b = Mocks.Original;
        b.IsCurrent = !a.IsCurrent;
        var comparer = new DataModel.OriginalValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_SessionIdIsDifferent()
    {
        var a = Mocks.Original;
        var b = Mocks.Original;
        b.SessionId += 1;
        var comparer = new DataModel.OriginalValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.Original;
        var b = Mocks.Original;
        b.PrecinctPortion = Mocks.PrecinctPortion;
        b.BallotType = Mocks.BallotType;
        b.Session = Mocks.Session;
        b.Cards = new List<Card>([Mocks.Card]);
        var comparer = new DataModel.OriginalValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
