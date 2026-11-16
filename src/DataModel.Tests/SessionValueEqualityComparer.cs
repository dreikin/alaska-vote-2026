using System.Diagnostics.CodeAnalysis;

namespace DataModel.Tests;

internal class DerivedSession : Session
{
    [SetsRequiredMembers]
    public DerivedSession(Session session)
    {
        Id = session.Id;
        ElectionEventId = session.ElectionEventId;
        ElectionEvent = session.ElectionEvent;
        TabulatorId = session.TabulatorId;
        Tabulator = session.Tabulator;
        BatchId = session.BatchId;
        RecordId = session.RecordId;
        CountingGroupId = session.CountingGroupId;
        CountingGroup = session.CountingGroup;
        ImageMask = session.ImageMask;
        SessionTypeId = session.SessionTypeId;
        SessionType = session.SessionType;
        VotingSessionIdentifier = session.VotingSessionIdentifier;
        UniqueVotingIdentifier = session.UniqueVotingIdentifier;
        Original = session.Original;
    }
}

public class SessionValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        Session? a = null;
        Session? b = null;
        var comparer = new DataModel.SessionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.Session;
        var comparer = new DataModel.SessionValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.Session;
        var b = Mocks.Session;
        var comparer = new DataModel.SessionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        Session? a = null;
        var b = Mocks.Session;
        var comparer = new DataModel.SessionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.Session;
        Session? b = null;
        var comparer = new DataModel.SessionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        Session a = new DerivedSession(Mocks.Session);
        var b = Mocks.Session;
        var comparer = new DataModel.SessionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.Session;
        var b = Mocks.Session;
        b.Id += 1;
        var comparer = new DataModel.SessionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ElectionEventIdIsDifferent()
    {
        var a = Mocks.Session;
        var b = Mocks.Session;
        b.ElectionEventId += 1;
        var comparer = new DataModel.SessionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_TabulatorIdIsDifferent()
    {
        var a = Mocks.Session;
        var b = Mocks.Session;
        b.TabulatorId += 1;
        var comparer = new DataModel.SessionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_BatchIdIsDifferent()
    {
        var a = Mocks.Session;
        var b = Mocks.Session;
        b.BatchId += 1;
        var comparer = new DataModel.SessionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_RecordIdIsDifferent()
    {
        var a = Mocks.Session;
        var b = Mocks.Session;
        b.RecordId += 1;
        var comparer = new DataModel.SessionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_CountingGroupIdIsDifferent()
    {
        var a = Mocks.Session;
        var b = Mocks.Session;
        b.CountingGroupId += 1;
        var comparer = new DataModel.SessionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ImageMaskIsDifferent()
    {
        var a = Mocks.Session;
        var b = Mocks.Session;
        b.ImageMask = @"D:\Temp\Ballots_To_Re-examine_*.*.jpg";
        var comparer = new DataModel.SessionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_SessionTypeIdIsDifferent()
    {
        var a = Mocks.Session;
        var b = Mocks.Session;
        b.SessionTypeId += 1;
        var comparer = new DataModel.SessionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_VotingSessionIdentifierIsDifferent()
    {
        var a = Mocks.Session;
        var b = Mocks.Session;
        b.VotingSessionIdentifier = "Aleph_null - 1";
        var comparer = new DataModel.SessionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_UniqueVotingIdentifierDifferent()
    {
        var a = Mocks.Session;
        var b = Mocks.Session;
        b.UniqueVotingIdentifier = "Aleph_null + 2";
        var comparer = new DataModel.SessionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.Session;
        var b = Mocks.Session;
        b.ElectionEvent = Mocks.ElectionEvent;
        b.Tabulator = Mocks.Tabulator;
        b.CountingGroup = Mocks.CountingGroup;
        b.SessionType = Mocks.SessionType;
        b.Original = Mocks.Original;
        var comparer = new DataModel.SessionValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
