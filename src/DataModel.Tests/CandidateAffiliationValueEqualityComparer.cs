using System.Diagnostics.CodeAnalysis;
using Tests.Common;

namespace DataModel.Tests;

internal class DerivedCandidateAffiliation : CandidateAffiliation
{
    [SetsRequiredMembers]
    public DerivedCandidateAffiliation(CandidateAffiliation candidateAffiliation)
    {
        CandidateId = candidateAffiliation.CandidateId;
        Candidate = candidateAffiliation.Candidate;
        PartyId = candidateAffiliation.PartyId;
        Party = candidateAffiliation.Party;
    }
}

public class CandidateAffiliationValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        CandidateAffiliation? a = null;
        CandidateAffiliation? b = null;
        var comparer = new DataModel.CandidateAffiliationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.CandidateAffiliation;
        var comparer = new DataModel.CandidateAffiliationValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.CandidateAffiliation;
        var b = Mocks.CandidateAffiliation;
        var comparer = new DataModel.CandidateAffiliationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        CandidateAffiliation? a = null;
        var b = Mocks.CandidateAffiliation;
        var comparer = new DataModel.CandidateAffiliationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.CandidateAffiliation;
        CandidateAffiliation? b = null;
        var comparer = new DataModel.CandidateAffiliationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        CandidateAffiliation a = new DerivedCandidateAffiliation(Mocks.CandidateAffiliation);
        var b = Mocks.CandidateAffiliation;
        var comparer = new DataModel.CandidateAffiliationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_CandidateIdIsDifferent()
    {
        var a = Mocks.CandidateAffiliation;
        var b = Mocks.CandidateAffiliation;
        b.CandidateId += 1;
        var comparer = new DataModel.CandidateAffiliationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_PartyIdIsDifferent()
    {
        var a = Mocks.CandidateAffiliation;
        var b = Mocks.CandidateAffiliation;
        b.PartyId += 1;
        var comparer = new DataModel.CandidateAffiliationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.CandidateAffiliation;
        var b = Mocks.CandidateAffiliation;
        b.Candidate = Mocks.Candidate;
        b.Party = Mocks.Party;
        var comparer = new DataModel.CandidateAffiliationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}