using System.Diagnostics.CodeAnalysis;

namespace DataModel.Tests;

internal class DerivedCandidate : Candidate
{
    [SetsRequiredMembers]
    public DerivedCandidate(Candidate candidate)
    {
        Id = candidate.Id;
        Description = candidate.Description;
        ExternalId = candidate.ExternalId;
        ContestId = candidate.ContestId;
        Contest = candidate.Contest;
        CandidateTypeId = candidate.CandidateTypeId;
        CandidateType = candidate.CandidateType;
        Disabled = candidate.Disabled;
        Marks = candidate.Marks;
        PartyAffiliations = candidate.PartyAffiliations;
    }
}

public class CandidateValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        Candidate? a = null;
        Candidate? b = null;
        var comparer = new DataModel.CandidateValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.Candidate;
        var comparer = new DataModel.CandidateValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.Candidate;
        var b = Mocks.Candidate;
        var comparer = new DataModel.CandidateValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        Candidate? a = null;
        var b = Mocks.Candidate;
        var comparer = new DataModel.CandidateValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.Candidate;
        Candidate? b = null;
        var comparer = new DataModel.CandidateValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        Candidate a = new DerivedCandidate(Mocks.Candidate);
        var b = Mocks.Candidate;
        var comparer = new DataModel.CandidateValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.Candidate;
        var b = Mocks.Candidate;
        b.Id += 1;
        var comparer = new DataModel.CandidateValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DescriptionIsDifferent()
    {
        var a = Mocks.Candidate;
        var b = Mocks.Candidate;
        b.Description = "Abraham Lincoln";
        var comparer = new DataModel.CandidateValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ExternalIdIsDifferent()
    {
        var a = Mocks.Candidate;
        var b = Mocks.Candidate;
        b.ExternalId = "The Second";
        var comparer = new DataModel.CandidateValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ContestIdIsDifferent()
    {
        var a = Mocks.Candidate;
        var b = Mocks.Candidate;
        b.ContestId += 1;
        var comparer = new DataModel.CandidateValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_CandidateTypeIdIsDifferent()
    {
        var a = Mocks.Candidate;
        var b = Mocks.Candidate;
        b.CandidateTypeId += 1;
        var comparer = new DataModel.CandidateValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DisabledIsDifferent()
    {
        var a = Mocks.Candidate;
        var b = Mocks.Candidate;
        b.Disabled = !a.Disabled;
        var comparer = new DataModel.CandidateValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.Candidate;
        var b = Mocks.Candidate;
        b.Contest = Mocks.Contest;
        b.CandidateType = Mocks.CandidateType;
        b.Marks = new List<Mark>([Mocks.Mark]);
        b.PartyAffiliations = new List<Party>([Mocks.Party]);
        var comparer = new DataModel.CandidateValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
