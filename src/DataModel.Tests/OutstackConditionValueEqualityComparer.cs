using System.Diagnostics.CodeAnalysis;

namespace DataModel.Tests;

internal class DerivedOutstackCondition : OutstackCondition
{
    [SetsRequiredMembers]
    public DerivedOutstackCondition(OutstackCondition outstackCondition)
    {
        Id = outstackCondition.Id;
        Description = outstackCondition.Description;
        CardContests = outstackCondition.CardContests;
        Cards = outstackCondition.Cards;
        Configurations = outstackCondition.Configurations;
        Marks = outstackCondition.Marks;
    }
}

public class OutstackConditionValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        OutstackCondition? a = null;
        OutstackCondition? b = null;
        var comparer = new DataModel.OutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.OutstackCondition;
        var comparer = new DataModel.OutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.OutstackCondition;
        var b = Mocks.OutstackCondition;
        var comparer = new DataModel.OutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        OutstackCondition? a = null;
        var b = Mocks.OutstackCondition;
        var comparer = new DataModel.OutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.OutstackCondition;
        OutstackCondition? b = null;
        var comparer = new DataModel.OutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        OutstackCondition a = new DerivedOutstackCondition(Mocks.OutstackCondition);
        var b = Mocks.OutstackCondition;
        var comparer = new DataModel.OutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.OutstackCondition;
        var b = Mocks.OutstackCondition;
        b.Id += 1;
        var comparer = new DataModel.OutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DescriptionIsDifferent()
    {
        var a = Mocks.OutstackCondition;
        var b = Mocks.OutstackCondition;
        b.Description = "Ran out of paper";
        var comparer = new DataModel.OutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.OutstackCondition;
        var b = Mocks.OutstackCondition;
        b.CardContests = new List<CardContest>([Mocks.CardContest]);
        b.Cards = new List<Card>([Mocks.Card]);
        b.Configurations = new List<Configuration>([Mocks.Configuration]);
        b.Marks = new List<Mark>([Mocks.Mark]);
        var comparer = new DataModel.OutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
