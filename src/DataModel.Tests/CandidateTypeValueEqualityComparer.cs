using System.Diagnostics.CodeAnalysis;

namespace DataModel.Tests;

internal class DerivedCandidateType : CandidateType
{
    [SetsRequiredMembers]
    public DerivedCandidateType(CandidateType candidateType)
    {
        Id = candidateType.Id;
        Description = candidateType.Description;
        Candidates = candidateType.Candidates;
    }
}

public class CandidateTypeValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        CandidateType? a = null;
        CandidateType? b = null;
        var comparer = new DataModel.CandidateTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.CandidateType;
        var comparer = new DataModel.CandidateTypeValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.CandidateType;
        var b = Mocks.CandidateType;
        var comparer = new DataModel.CandidateTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        CandidateType? a = null;
        var b = Mocks.CandidateType;
        var comparer = new DataModel.CandidateTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.CandidateType;
        CandidateType? b = null;
        var comparer = new DataModel.CandidateTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        CandidateType a = new DerivedCandidateType(Mocks.CandidateType);
        var b = Mocks.CandidateType;
        var comparer = new DataModel.CandidateTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.CandidateType;
        var b = Mocks.CandidateType;
        b.Id += 1;
        var comparer = new DataModel.CandidateTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DescriptionIsDifferent()
    {
        var a = Mocks.CandidateType;
        var b = Mocks.CandidateType;
        b.Description += "Underdog";
        var comparer = new DataModel.CandidateTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.CandidateType;
        var b = Mocks.CandidateType;
        b.Candidates = new List<Candidate>([Mocks.Candidate]);
        var comparer = new DataModel.CandidateTypeValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
