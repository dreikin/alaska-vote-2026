namespace DataModel.Tests;

internal class DerivedBallotTypeContest : BallotTypeContest
{
}

public class BallotTypeContestEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        BallotTypeContest? a = null;
        BallotTypeContest? b = null;
        var comparer = new DataModel.BallotTypeContestEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        BallotTypeContest a = new() { BallotTypeId = 1, ContestId = 2 };
        var comparer = new DataModel.BallotTypeContestEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        BallotTypeContest a = new() { BallotTypeId = 1, ContestId = 2 };
        BallotTypeContest b = new() { BallotTypeId = 1, ContestId = 2 };
        var comparer = new DataModel.BallotTypeContestEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        BallotTypeContest? a = null;
        BallotTypeContest b = new() { BallotTypeId = 1, ContestId = 2 };
        var comparer = new DataModel.BallotTypeContestEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        BallotTypeContest a = new() { BallotTypeId = 1, ContestId = 2 };
        BallotTypeContest? b = null;
        var comparer = new DataModel.BallotTypeContestEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        BallotTypeContest a = new DerivedBallotTypeContest { BallotTypeId = 1, ContestId = 2 };
        BallotTypeContest b = new() { BallotTypeId = 1, ContestId = 2 };
        var comparer = new DataModel.BallotTypeContestEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_BallotTypeIdIsDifferent()
    {
        BallotTypeContest a = new() { BallotTypeId = 1, ContestId = 2 };
        BallotTypeContest b = new() { BallotTypeId = 2, ContestId = 2 };
        var comparer = new DataModel.BallotTypeContestEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ContestIdIsDifferent()
    {
        BallotTypeContest a = new() { BallotTypeId = 1, ContestId = 2 };
        BallotTypeContest b = new() { BallotTypeId = 1, ContestId = 3 };
        var comparer = new DataModel.BallotTypeContestEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var ballotType = new BallotType
        {
            Id = 1,
            Description = "Type 1"
        };
        var contest = new Contest
        {
            Id = 2,
            Description = "Governor",
            DistrictId = 0,
            VoteFor = 0,
            NumOfRanks = 0,
            NumOfWriteins = 0,
            Disabled = false,
            ContestTypeId = 0
        };
        BallotTypeContest a = new()
            { BallotTypeId = 1, ContestId = 2, BallotType = ballotType, Contest = contest };
        BallotTypeContest b = new() { BallotTypeId = 1, ContestId = 2 };
        var comparer = new DataModel.BallotTypeContestEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
