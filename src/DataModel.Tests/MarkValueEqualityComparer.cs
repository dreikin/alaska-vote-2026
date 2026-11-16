using System.Diagnostics.CodeAnalysis;
using Tests.Common;

namespace DataModel.Tests;

internal class DerivedMark : Mark
{
    [SetsRequiredMembers]
    public DerivedMark(Mark mark)
    {
        Id = mark.Id;
        ManifestationId = mark.ManifestationId;
        CardContestId = mark.CardContestId;
        CardContest = mark.CardContest;
        CandidateId = mark.CandidateId;
        Candidate = mark.Candidate;
        PartyId = mark.PartyId;
        Party = mark.Party;
        Rank = mark.Rank;
        MarkDensity = mark.MarkDensity;
        IsAmbiguous = mark.IsAmbiguous;
        IsVote = mark.IsVote;
        OutstackConditions = mark.OutstackConditions;
    }
}

public class MarkValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        Mark? a = null;
        Mark? b = null;
        var comparer = new DataModel.MarkValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.Mark;
        var comparer = new DataModel.MarkValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.Mark;
        var b = Mocks.Mark;
        var comparer = new DataModel.MarkValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        Mark? a = null;
        var b = Mocks.Mark;
        var comparer = new DataModel.MarkValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.Mark;
        Mark? b = null;
        var comparer = new DataModel.MarkValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        Mark a = new DerivedMark(Mocks.Mark);
        var b = Mocks.Mark;
        var comparer = new DataModel.MarkValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.Mark;
        var b = Mocks.Mark;
        b.Id += 1;
        var comparer = new DataModel.MarkValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ManifestationIdIsDifferent()
    {
        var a = Mocks.Mark;
        var b = Mocks.Mark;
        b.ManifestationId += 1;
        var comparer = new DataModel.MarkValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_CardContestIdIsDifferent()
    {
        var a = Mocks.Mark;
        var b = Mocks.Mark;
        b.CardContestId += 1;
        var comparer = new DataModel.MarkValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_CandidateIdIsDifferent()
    {
        var a = Mocks.Mark;
        var b = Mocks.Mark;
        b.CardContestId += 1;
        var comparer = new DataModel.MarkValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_PartyIdIsDifferent()
    {
        var a = Mocks.Mark;
        var b = Mocks.Mark;
        b.PartyId += 1;
        var comparer = new DataModel.MarkValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_RankIsDifferent()
    {
        var a = Mocks.Mark;
        var b = Mocks.Mark;
        b.Rank += 1;
        var comparer = new DataModel.MarkValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_MarkDensityIsDifferent()
    {
        var a = Mocks.Mark;
        var b = Mocks.Mark;
        b.MarkDensity += 1;
        var comparer = new DataModel.MarkValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IsAmbiguousIsDifferent()
    {
        var a = Mocks.Mark;
        var b = Mocks.Mark;
        b.IsAmbiguous = !a.IsAmbiguous;
        var comparer = new DataModel.MarkValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IsVoteIsDifferent()
    {
        var a = Mocks.Mark;
        var b = Mocks.Mark;
        b.IsVote = !a.IsVote;
        var comparer = new DataModel.MarkValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.Mark;
        var b = Mocks.Mark;
        b.CardContest = Mocks.CardContest;
        b.Candidate = Mocks.Candidate;
        b.Party = Mocks.Party;
        b.OutstackConditions = new List<OutstackCondition>([Mocks.OutstackCondition]);
        var comparer = new DataModel.MarkValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}