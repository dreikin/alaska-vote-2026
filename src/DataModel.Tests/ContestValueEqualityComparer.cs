using System.Diagnostics.CodeAnalysis;

namespace DataModel.Tests;

internal class DerivedContest : Contest
{
    [SetsRequiredMembers]
    public DerivedContest(Contest contest)
    {
        Id = contest.Id;
        Description = contest.Description;
        ExternalId = contest.ExternalId;
        DistrictId = contest.DistrictId;
        District = contest.District;
        VoteFor = contest.VoteFor;
        NumOfRanks = contest.NumOfRanks;
        NumOfWriteins = contest.NumOfWriteins;
        Disabled = contest.Disabled;
        ContestTypeId = contest.ContestTypeId;
        ContestType = contest.ContestType;
        BallotTypes = contest.BallotTypes;
        Candidates = contest.Candidates;
        CardContests = contest.CardContests;
    }
}

public class ContestValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        Contest? a = null;
        Contest? b = null;
        var comparer = new DataModel.ContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.Contest;
        var comparer = new DataModel.ContestValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.Contest;
        var b = Mocks.Contest;
        var comparer = new DataModel.ContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        Contest? a = null;
        var b = Mocks.Contest;
        var comparer = new DataModel.ContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.Contest;
        Contest? b = null;
        var comparer = new DataModel.ContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        Contest a = new DerivedContest(Mocks.Contest);
        var b = Mocks.Contest;
        var comparer = new DataModel.ContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.Contest;
        var b = Mocks.Contest;
        b.Id += 1;
        var comparer = new DataModel.ContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DescriptionIsDifferent()
    {
        var a = Mocks.Contest;
        var b = Mocks.Contest;
        b.Description = "Mayoral Supremacy";
        var comparer = new DataModel.ContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ExternalIdIsDifferent()
    {
        var a = Mocks.Contest;
        var b = Mocks.Contest;
        b.ExternalId = "To The Breadth";
        var comparer = new DataModel.ContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DistrictIdIsDifferent()
    {
        var a = Mocks.Contest;
        var b = Mocks.Contest;
        b.DistrictId += 1;
        var comparer = new DataModel.ContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_VoteForIsDifferent()
    {
        var a = Mocks.Contest;
        var b = Mocks.Contest;
        b.VoteFor += 1;
        var comparer = new DataModel.ContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_NumOfRanksIsDifferent()
    {
        var a = Mocks.Contest;
        var b = Mocks.Contest;
        b.NumOfRanks += 1;
        var comparer = new DataModel.ContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_NumOfWriteinsDifferent()
    {
        var a = Mocks.Contest;
        var b = Mocks.Contest;
        b.NumOfWriteins += 1;
        var comparer = new DataModel.ContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DisabledIsDifferent()
    {
        var a = Mocks.Contest;
        var b = Mocks.Contest;
        b.Disabled = !a.Disabled;
        var comparer = new DataModel.ContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ContestTypeIdIsDifferent()
    {
        var a = Mocks.Contest;
        var b = Mocks.Contest;
        b.ContestTypeId += 1;
        var comparer = new DataModel.ContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.Contest;
        var b = Mocks.Contest;
        b.District = Mocks.District;
        b.ContestType = Mocks.ContestType;
        b.BallotTypes = new List<BallotType>([Mocks.BallotType]);
        b.Candidates = new List<Candidate>([Mocks.Candidate]);
        b.CardContests = new List<CardContest>([Mocks.CardContest]);
        var comparer = new DataModel.ContestValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
