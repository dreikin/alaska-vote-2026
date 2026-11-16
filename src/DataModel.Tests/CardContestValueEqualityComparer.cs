using System.Diagnostics.CodeAnalysis;
using Tests.Common;

namespace DataModel.Tests;

internal class DerivedCardContest : CardContest
{
    [SetsRequiredMembers]
    public DerivedCardContest(CardContest cardContest)
    {
        Id = cardContest.Id;
        ManifestationId = cardContest.ManifestationId;
        CardId = cardContest.CardId;
        Card = cardContest.Card;
        ContestId = cardContest.ContestId;
        Contest = cardContest.Contest;
        Undervotes = cardContest.Undervotes;
        Overvotes = cardContest.Overvotes;
        OutstackConditions = cardContest.OutstackConditions;
        Marks = cardContest.Marks;
    }
}

public class CardContestValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        CardContest? a = null;
        CardContest? b = null;
        var comparer = new DataModel.CardContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.CardContest;
        var comparer = new DataModel.CardContestValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.CardContest;
        var b = Mocks.CardContest;
        var comparer = new DataModel.CardContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        CardContest? a = null;
        var b = Mocks.CardContest;
        var comparer = new DataModel.CardContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.CardContest;
        CardContest? b = null;
        var comparer = new DataModel.CardContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        CardContest a = new DerivedCardContest(Mocks.CardContest);
        var b = Mocks.CardContest;
        var comparer = new DataModel.CardContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.CardContest;
        var b = Mocks.CardContest;
        b.Id += 1;
        var comparer = new DataModel.CardContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ManifestationIdIsDifferent()
    {
        var a = Mocks.CardContest;
        var b = Mocks.CardContest;
        b.ManifestationId += 1;
        var comparer = new DataModel.CardContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_CardIdIsDifferent()
    {
        var a = Mocks.CardContest;
        var b = Mocks.CardContest;
        b.CardId += 1;
        var comparer = new DataModel.CardContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ContestIsDifferent()
    {
        var a = Mocks.CardContest;
        var b = Mocks.CardContest;
        b.ContestId += 1;
        var comparer = new DataModel.CardContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_UndervotesIsDifferent()
    {
        var a = Mocks.CardContest;
        var b = Mocks.CardContest;
        b.Undervotes += 1;
        var comparer = new DataModel.CardContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_OvervotesIsDifferent()
    {
        var a = Mocks.CardContest;
        var b = Mocks.CardContest;
        b.Overvotes += 1;
        var comparer = new DataModel.CardContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.CardContest;
        var b = Mocks.CardContest;
        b.Card = Mocks.Card;
        b.Contest = Mocks.Contest;
        b.OutstackConditions = new List<OutstackCondition>([Mocks.OutstackCondition]);
        b.Marks = new List<Mark>([Mocks.Mark]);
        var comparer = new DataModel.CardContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}