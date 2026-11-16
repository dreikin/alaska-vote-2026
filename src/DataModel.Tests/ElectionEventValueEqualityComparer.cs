using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

namespace DataModel.Tests;

internal class DerivedElectionEvent : ElectionEvent
{
    [SetsRequiredMembers]
    public DerivedElectionEvent(ElectionEvent electionEvent)
    {
        Id = electionEvent.Id;
        Description = electionEvent.Description;
        ExternalId = electionEvent.ExternalId;
        JurisdictionId = electionEvent.JurisdictionId;
        Jurisdiction = electionEvent.Jurisdiction;
        ElectionDate = electionEvent.ElectionDate;
        ElectionSignature = electionEvent.ElectionSignature;
        Sessions = electionEvent.Sessions;
    }
}

public class ElectionEventValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        ElectionEvent? a = null;
        ElectionEvent? b = null;
        var comparer = new DataModel.ElectionEventValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.ElectionEvent;
        var comparer = new DataModel.ElectionEventValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.ElectionEvent;
        var b = Mocks.ElectionEvent;
        var comparer = new DataModel.ElectionEventValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        ElectionEvent? a = null;
        var b = Mocks.ElectionEvent;
        var comparer = new DataModel.ElectionEventValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.ElectionEvent;
        ElectionEvent? b = null;
        var comparer = new DataModel.ElectionEventValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        ElectionEvent a = new DerivedElectionEvent(Mocks.ElectionEvent);
        var b = Mocks.ElectionEvent;
        var comparer = new DataModel.ElectionEventValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.ElectionEvent;
        var b = Mocks.ElectionEvent;
        b.Id += 1;
        var comparer = new DataModel.ElectionEventValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DescriptionIsDifferent()
    {
        var a = Mocks.ElectionEvent;
        var b = Mocks.ElectionEvent;
        b.Description = "Local 1776";
        var comparer = new DataModel.ElectionEventValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ExternalIdIsDifferent()
    {
        var a = Mocks.ElectionEvent;
        var b = Mocks.ElectionEvent;
        b.ExternalId = "Juno, Alaska Mayor 1776";
        var comparer = new DataModel.ElectionEventValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_JurisdictionIdIsDifferent()
    {
        var a = Mocks.ElectionEvent;
        var b = Mocks.ElectionEvent;
        b.JurisdictionId += 1;
        var comparer = new DataModel.ElectionEventValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ElectionDateIsDifferent()
    {
        var a = Mocks.ElectionEvent;
        var b = Mocks.ElectionEvent;
        b.ElectionDate = a.ElectionDate.AddDays(1);
        var comparer = new DataModel.ElectionEventValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ElectionSignatureIsDifferent()
    {
        var a = Mocks.ElectionEvent;
        var b = Mocks.ElectionEvent;
        b.ElectionSignature = SHA256.HashData(a.ElectionSignature);
        var comparer = new DataModel.ElectionEventValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.ElectionEvent;
        var b = Mocks.ElectionEvent;
        b.Jurisdiction = Mocks.Jurisdiction;
        b.Sessions = new List<Session>([Mocks.Session]);
        var comparer = new DataModel.ElectionEventValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
