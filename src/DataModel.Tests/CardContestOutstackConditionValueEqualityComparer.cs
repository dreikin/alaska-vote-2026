using System.Diagnostics.CodeAnalysis;
using Tests.Common;

namespace DataModel.Tests;

internal class DerivedCardContestOutstackCondition : CardContestOutstackCondition
{
    [SetsRequiredMembers]
    public DerivedCardContestOutstackCondition(CardContestOutstackCondition cardContestOutstackCondition)
    {
        CardContestId = cardContestOutstackCondition.CardContestId;
        CardContest = cardContestOutstackCondition.CardContest;
        OutstackConditionId = cardContestOutstackCondition.OutstackConditionId;
        OutstackCondition = cardContestOutstackCondition.OutstackCondition;
    }
}

public class CardContestOutstackConditionValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        CardContestOutstackCondition? a = null;
        CardContestOutstackCondition? b = null;
        var comparer = new DataModel.CardContestOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.CardContestOutstackCondition;
        var comparer = new DataModel.CardContestOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.CardContestOutstackCondition;
        var b = Mocks.CardContestOutstackCondition;
        var comparer = new DataModel.CardContestOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        CardContestOutstackCondition? a = null;
        var b = Mocks.CardContestOutstackCondition;
        var comparer = new DataModel.CardContestOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.CardContestOutstackCondition;
        CardContestOutstackCondition? b = null;
        var comparer = new DataModel.CardContestOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        CardContestOutstackCondition a = new DerivedCardContestOutstackCondition(Mocks.CardContestOutstackCondition);
        var b = Mocks.CardContestOutstackCondition;
        var comparer = new DataModel.CardContestOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_CardContestIdIsDifferent()
    {
        var a = Mocks.CardContestOutstackCondition;
        var b = Mocks.CardContestOutstackCondition;
        b.CardContestId += 1;
        var comparer = new DataModel.CardContestOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_OutstackConditionIdIsDifferent()
    {
        var a = Mocks.CardContestOutstackCondition;
        var b = Mocks.CardContestOutstackCondition;
        b.OutstackConditionId += 1;
        var comparer = new DataModel.CardContestOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.CardContestOutstackCondition;
        var b = Mocks.CardContestOutstackCondition;
        b.CardContest = Mocks.CardContest;
        b.OutstackCondition = Mocks.OutstackCondition;
        var comparer = new DataModel.CardContestOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}