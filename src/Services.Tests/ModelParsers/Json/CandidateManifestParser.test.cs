using System.Text;
using DataModel;
using DataModel.Constants;
using Repository;

namespace Services.Tests.ModelParsers.Json;

public class CandidateManifestParser
{
    private const string SingleItemList = """
                                          {
                                              "Version": "5.17.18.1",
                                              "List": [
                                                  {
                                                      "Description": "Heikes, Gerald L.",
                                                      "Id": 524,
                                                      "ExternalId": "",
                                                      "ContestId": 6,
                                                      "Type": "Regular",
                                                      "Disabled": 0,
                                                      "Affiliations": [
                                                          15
                                                      ]
                                                  },
                                              ]
                                          }
                                          """;

    private readonly (int CandidateId, int PartyId) _expectedCandidateAffiliation = new(524, 15);

    private readonly Candidate _expectedSingle = new()
    {
        Description = "Heikes, Gerald L.", Id = 524, ExternalId = "", ContestId = 6, CandidateTypeId = 999,
        Disabled = false
    };

    [Test]
    public async Task Parse_Adds_TableVersion_For_Candidate()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        repository.FindOrAddCandidateType(Any()).ReturnsAsync(Task.FromResult(999));
        repository.AddCandidate(Any<Candidate>()).ReturnsAsync(candidate => Task.FromResult(candidate.Id));
        var parser = new Services.ModelParsers.Json.CandidateManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddTableVersion(Any(), Any())).WasCalled(Times.Exactly(3));
        await Assert.That(repository.AddTableVersion(CollectionNames.Candidate, "5.17.18.1")).WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_TableVersion_For_CandidateType()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        repository.FindOrAddCandidateType(Any()).ReturnsAsync(Task.FromResult(999));
        repository.AddCandidate(Any<Candidate>()).ReturnsAsync(candidate => Task.FromResult(candidate.Id));
        var parser = new Services.ModelParsers.Json.CandidateManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddTableVersion(Any(), Any())).WasCalled(Times.Exactly(3));
        await Assert.That(repository.AddTableVersion(CollectionNames.CandidateType, "5.17.18.1")).WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_TableVersion_For_CandidateAffiliation()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        repository.FindOrAddCandidateType(Any()).ReturnsAsync(Task.FromResult(999));
        repository.AddCandidate(Any<Candidate>()).ReturnsAsync(candidate => Task.FromResult(candidate.Id));
        var parser = new Services.ModelParsers.Json.CandidateManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddTableVersion(Any(), Any())).WasCalled(Times.Exactly(3));
        await Assert.That(repository.AddTableVersion(CollectionNames.CandidateAffiliation, "5.17.18.1"))
            .WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_Candidate()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        repository.FindOrAddCandidateType(Any()).ReturnsAsync(Task.FromResult(999));
        repository.AddCandidate(Any<Candidate>()).ReturnsAsync(candidate => Task.FromResult(candidate.Id));
        var parser = new Services.ModelParsers.Json.CandidateManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddCandidate(Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.AddCandidate(Is<Candidate>(actual =>
                actual.Description == _expectedSingle.Description)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddCandidate(Is<Candidate>(actual => actual.Id == _expectedSingle.Id)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddCandidate(Is<Candidate>(actual =>
                actual.ExternalId == _expectedSingle.ExternalId)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddCandidate(Is<Candidate>(actual =>
                actual.ContestId == _expectedSingle.ContestId)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddCandidate(Is<Candidate>(actual =>
                actual.CandidateTypeId == _expectedSingle.CandidateTypeId)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddCandidate(Is<Candidate>(actual =>
                actual.Disabled == _expectedSingle.Disabled)))
            .WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_CandidateType()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        repository.FindOrAddCandidateType(Any()).ReturnsAsync(Task.FromResult(999));
        repository.AddCandidate(Any<Candidate>()).ReturnsAsync(candidate => Task.FromResult(candidate.Id));
        var parser = new Services.ModelParsers.Json.CandidateManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.FindOrAddCandidateType(Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.FindOrAddCandidateType("Regular"))
            .WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_CandidateAffiliation()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        repository.FindOrAddCandidateType(Any()).ReturnsAsync(Task.FromResult(999));
        repository.AddCandidate(Any<Candidate>()).ReturnsAsync(candidate => Task.FromResult(candidate.Id));
        var parser = new Services.ModelParsers.Json.CandidateManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddCandidateAffiliation(Any(), Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.AddCandidateAffiliation(_expectedCandidateAffiliation.CandidateId,
                _expectedCandidateAffiliation.PartyId))
            .WasCalled(Times.Once);
    }
}
