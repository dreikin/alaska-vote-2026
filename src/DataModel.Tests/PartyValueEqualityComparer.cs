using System.Diagnostics.CodeAnalysis;
using Tests.Common;

namespace DataModel.Tests;

internal class DerivedParty : Party
{
    [SetsRequiredMembers]
    public DerivedParty(Party party)
    {
        Id = party.Id;
        Description = party.Description;
        ExternalId = party.ExternalId;
        CandidateAffiliations = party.CandidateAffiliations;
        Marks = party.Marks;
    }
}

public class PartyValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        Party? a = null;
        Party? b = null;
        var comparer = new DataModel.PartyValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.Party;
        var comparer = new DataModel.PartyValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.Party;
        var b = Mocks.Party;
        var comparer = new DataModel.PartyValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        Party? a = null;
        var b = Mocks.Party;
        var comparer = new DataModel.PartyValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.Party;
        Party? b = null;
        var comparer = new DataModel.PartyValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        Party a = new DerivedParty(Mocks.Party);
        var b = Mocks.Party;
        var comparer = new DataModel.PartyValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.Party;
        var b = Mocks.Party;
        b.Id += 1;
        var comparer = new DataModel.PartyValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DescriptionIsDifferent()
    {
        var a = Mocks.Party;
        var b = Mocks.Party;
        b.Description = "We might think we know something you don't know";
        var comparer = new DataModel.PartyValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ExternalIdIsDifferent()
    {
        var a = Mocks.Party;
        var b = Mocks.Party;
        b.ExternalId = "Know-Nothings";
        var comparer = new DataModel.PartyValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.Party;
        var b = Mocks.Party;
        b.CandidateAffiliations = new List<Candidate>([Mocks.Candidate]);
        b.Marks = new List<Mark>([Mocks.Mark]);
        var comparer = new DataModel.PartyValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
