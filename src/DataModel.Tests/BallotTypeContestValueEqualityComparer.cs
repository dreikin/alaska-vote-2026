using System.Diagnostics.CodeAnalysis;
using Tests.Common;

namespace DataModel.Tests;

internal class DerivedBallotTypeContest : BallotTypeContest
{
    [SetsRequiredMembers]
    public DerivedBallotTypeContest(BallotTypeContest ballotTypeContest)
    {
        BallotType = ballotTypeContest.BallotType;
        BallotType = ballotTypeContest.BallotType;
        ContestId = ballotTypeContest.ContestId;
        Contest = ballotTypeContest.Contest;
    }
}

public class BallotTypeContestValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        BallotTypeContest? a = null;
        BallotTypeContest? b = null;
        var comparer = new DataModel.BallotTypeContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.BallotTypeContest;
        var comparer = new DataModel.BallotTypeContestValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.BallotTypeContest;
        var b = Mocks.BallotTypeContest;
        var comparer = new DataModel.BallotTypeContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        BallotTypeContest? a = null;
        var b = Mocks.BallotTypeContest;
        var comparer = new DataModel.BallotTypeContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.BallotTypeContest;
        BallotTypeContest? b = null;
        var comparer = new DataModel.BallotTypeContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        BallotTypeContest a = new DerivedBallotTypeContest(Mocks.BallotTypeContest);
        var b = Mocks.BallotTypeContest;
        var comparer = new DataModel.BallotTypeContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_BallotTypeIdIsDifferent()
    {
        var a = Mocks.BallotTypeContest;
        var b = Mocks.BallotTypeContest;
        b.BallotTypeId += 1;
        var comparer = new DataModel.BallotTypeContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ContestIdIsDifferent()
    {
        var a = Mocks.BallotTypeContest;
        var b = Mocks.BallotTypeContest;
        b.ContestId += 1;
        var comparer = new DataModel.BallotTypeContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.BallotTypeContest;
        var b = Mocks.BallotTypeContest;
        b.BallotType = Mocks.BallotType;
        b.Contest = Mocks.Contest;
        var comparer = new DataModel.BallotTypeContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}