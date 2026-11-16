using System.Diagnostics.CodeAnalysis;

namespace DataModel.Tests;

internal class DerivedCard : Card
{
    [SetsRequiredMembers]
    public DerivedCard(Card card)
    {
        Id = card.Id;
        CardId = card.CardId;
        KeyInId = card.KeyInId;
        PaperIndex = card.PaperIndex;
        OriginalId = card.OriginalId;
        Original = card.Original;
        CardContests = card.CardContests;
        OutstackConditions = card.OutstackConditions;
    }
}

public class CardValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        Card? a = null;
        Card? b = null;
        var comparer = new DataModel.CardValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.Card;
        var comparer = new DataModel.CardValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.Card;
        var b = Mocks.Card;
        var comparer = new DataModel.CardValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        Card? a = null;
        var b = Mocks.Card;
        var comparer = new DataModel.CardValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.Card;
        Card? b = null;
        var comparer = new DataModel.CardValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        Card a = new DerivedCard(Mocks.Card);
        var b = Mocks.Card;
        var comparer = new DataModel.CardValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.Card;
        var b = Mocks.Card;
        b.Id += 1;
        var comparer = new DataModel.CardValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_CardIdIsDifferent()
    {
        var a = Mocks.Card;
        var b = Mocks.Card;
        b.CardId += 1;
        var comparer = new DataModel.CardValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_KeyInIdIsDifferent()
    {
        var a = Mocks.Card;
        var b = Mocks.Card;
        b.KeyInId += 1;
        var comparer = new DataModel.CardValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_PaperIndexIsDifferent()
    {
        var a = Mocks.Card;
        var b = Mocks.Card;
        b.PaperIndex += 1;
        var comparer = new DataModel.CardValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_OriginalIdIsDifferent()
    {
        var a = Mocks.Card;
        var b = Mocks.Card;
        b.OriginalId += 1;
        var comparer = new DataModel.CardValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.Card;
        var b = Mocks.Card;
        b.Original = Mocks.Original;
        b.CardContests = new List<CardContest>([Mocks.CardContest]);
        b.OutstackConditions = new List<OutstackCondition>([Mocks.OutstackCondition]);
        var comparer = new DataModel.CardValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
