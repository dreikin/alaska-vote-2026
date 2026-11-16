using System.Diagnostics.CodeAnalysis;
using Tests.Common;

namespace DataModel.Tests;

internal class DerivedCardOutstackCondition : CardOutstackCondition
{
    [SetsRequiredMembers]
    public DerivedCardOutstackCondition(CardOutstackCondition cardOutstackCondition)
    {
        CardId = cardOutstackCondition.CardId;
        Card = cardOutstackCondition.Card;
        OutstackConditionId = cardOutstackCondition.OutstackConditionId;
        OutstackCondition = cardOutstackCondition.OutstackCondition;
    }
}

public class CardOutstackConditionValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        CardOutstackCondition? a = null;
        CardOutstackCondition? b = null;
        var comparer = new DataModel.CardOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.CardOutstackCondition;
        var comparer = new DataModel.CardOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.CardOutstackCondition;
        var b = Mocks.CardOutstackCondition;
        var comparer = new DataModel.CardOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        CardOutstackCondition? a = null;
        var b = Mocks.CardOutstackCondition;
        var comparer = new DataModel.CardOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.CardOutstackCondition;
        CardOutstackCondition? b = null;
        var comparer = new DataModel.CardOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        CardOutstackCondition a = new DerivedCardOutstackCondition(Mocks.CardOutstackCondition);
        var b = Mocks.CardOutstackCondition;
        var comparer = new DataModel.CardOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_CardIdIsDifferent()
    {
        var a = Mocks.CardOutstackCondition;
        var b = Mocks.CardOutstackCondition;
        b.CardId += 1;
        var comparer = new DataModel.CardOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_OutstackConditionIdIsDifferent()
    {
        var a = Mocks.CardOutstackCondition;
        var b = Mocks.CardOutstackCondition;
        b.OutstackConditionId += 1;
        var comparer = new DataModel.CardOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.CardOutstackCondition;
        var b = Mocks.CardOutstackCondition;
        b.Card = Mocks.Card;
        b.OutstackCondition = Mocks.OutstackCondition;
        var comparer = new DataModel.CardOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}