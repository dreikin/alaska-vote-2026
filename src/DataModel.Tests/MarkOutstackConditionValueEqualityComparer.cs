using System.Diagnostics.CodeAnalysis;

namespace DataModel.Tests;

internal class DerivedMarkOutstackCondition : MarkOutstackCondition
{
    [SetsRequiredMembers]
    public DerivedMarkOutstackCondition(MarkOutstackCondition markOutstackCondition)
    {
        MarkId = markOutstackCondition.MarkId;
        Mark = markOutstackCondition.Mark;
        OutstackConditionId = markOutstackCondition.OutstackConditionId;
        OutstackCondition = markOutstackCondition.OutstackCondition;
    }
}

public class MarkOutstackConditionValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        MarkOutstackCondition? a = null;
        MarkOutstackCondition? b = null;
        var comparer = new DataModel.MarkOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.MarkOutstackCondition;
        var comparer = new DataModel.MarkOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.MarkOutstackCondition;
        var b = Mocks.MarkOutstackCondition;
        var comparer = new DataModel.MarkOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        MarkOutstackCondition? a = null;
        var b = Mocks.MarkOutstackCondition;
        var comparer = new DataModel.MarkOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.MarkOutstackCondition;
        MarkOutstackCondition? b = null;
        var comparer = new DataModel.MarkOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        MarkOutstackCondition a = new DerivedMarkOutstackCondition(Mocks.MarkOutstackCondition);
        var b = Mocks.MarkOutstackCondition;
        var comparer = new DataModel.MarkOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_MarkIdIsDifferent()
    {
        var a = Mocks.MarkOutstackCondition;
        var b = Mocks.MarkOutstackCondition;
        b.MarkId += 1;
        var comparer = new DataModel.MarkOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_OutstackConditionIdIsDifferent()
    {
        var a = Mocks.MarkOutstackCondition;
        var b = Mocks.MarkOutstackCondition;
        b.OutstackConditionId += 1;
        var comparer = new DataModel.MarkOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.MarkOutstackCondition;
        var b = Mocks.MarkOutstackCondition;
        b.Mark = Mocks.Mark;
        b.OutstackCondition = Mocks.OutstackCondition;
        var comparer = new DataModel.MarkOutstackConditionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
