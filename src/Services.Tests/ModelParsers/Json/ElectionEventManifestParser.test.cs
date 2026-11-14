using System.Text;
using DataModel;
using DataModel.Constants;
using VoteRepository;

namespace Services.Tests.ModelParsers.Json;

public class ElectionEventManifestParser
{
    private const string SingleItemList = """
                                          {
                                              "Version": "5.17.18.1",
                                              "List": [
                                                  {
                                                      "Description": "2026 General Election",
                                                      "Id": 1,
                                                      "ExternalId": "",
                                                      "Jurisdiction": "State of Alaska",
                                                      "ElectionDate": "20261103",
                                                      "ElectionSignature": [
                                                          101,
                                                          70,
                                                          94,
                                                          50,
                                                          51,
                                                          120,
                                                          84,
                                                          33,
                                                          103,
                                                          89,
                                                          126,
                                                          57,
                                                          91,
                                                          102,
                                                          53,
                                                          69,
                                                          110,
                                                          55,
                                                          87,
                                                          36,
                                                          48,
                                                          63,
                                                          114,
                                                          71,
                                                          99,
                                                          54,
                                                          81,
                                                          124,
                                                          37,
                                                          67,
                                                          113,
                                                          56
                                                      ]
                                                  }
                                              ]
                                          }
                                          """;

    private readonly ElectionEvent _expectedSingleElectionEvent = new()
    {
        Description = "2026 General Election", Id = 1, ExternalId = "", JurisdictionId = 42,
        ElectionDate = new DateOnly(2026, 11, 03),
        ElectionSignature =
        [
            101, 70, 94, 50, 51, 120, 84, 33, 103, 89, 126, 57, 91, 102, 53, 69, 110, 55, 87, 36, 48, 63, 114, 71, 99,
            54, 81, 124, 37, 67, 113, 56
        ]
    };

    private readonly Jurisdiction _expectedSingleJurisdiction = new() { Id = 42, Description = "State of Alaska" };

    [Test]
    public async Task Parse_Adds_TableVersion_For_ElectionEvent()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        repository.FindOrAddJurisdiction(Any()).ReturnsAsync(Task.FromResult(42));
        var parser = new Services.ModelParsers.Json.ElectionEventManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddTableVersion(Any(), Any())).WasCalled(Times.Exactly(2));
        await Assert.That(repository.AddTableVersion(CollectionNames.ElectionEvent, "5.17.18.1")).WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_TableVersion_For_Jurisdiction()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        repository.FindOrAddJurisdiction(Any()).ReturnsAsync(Task.FromResult(42));
        var parser = new Services.ModelParsers.Json.ElectionEventManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddTableVersion(Any(), Any())).WasCalled(Times.Exactly(2));
        await Assert.That(repository.AddTableVersion(CollectionNames.Jurisdiction, "5.17.18.1")).WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_ElectionEvent()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        repository.FindOrAddJurisdiction(Any()).ReturnsAsync(Task.FromResult(42));
        var parser = new Services.ModelParsers.Json.ElectionEventManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddElectionEvent(Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.AddElectionEvent(Is<ElectionEvent>(actual =>
                actual.Description == _expectedSingleElectionEvent.Description)))
            .WasCalled(Times.Once);
        await Assert
            .That(
                repository.AddElectionEvent(Is<ElectionEvent>(actual => actual.Id == _expectedSingleElectionEvent.Id)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddElectionEvent(Is<ElectionEvent>(actual =>
                actual.ExternalId == _expectedSingleElectionEvent.ExternalId)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddElectionEvent(Is<ElectionEvent>(actual =>
                actual.JurisdictionId == _expectedSingleElectionEvent.JurisdictionId)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddElectionEvent(Is<ElectionEvent>(actual =>
                actual.ElectionDate == _expectedSingleElectionEvent.ElectionDate)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddElectionEvent(Is<ElectionEvent>(actual =>
                Enumerable.SequenceEqual(actual.ElectionSignature, _expectedSingleElectionEvent.ElectionSignature))))
            .WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_Jurisdiction()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        repository.FindOrAddJurisdiction(Any()).ReturnsAsync(Task.FromResult(42));
        var parser = new Services.ModelParsers.Json.ElectionEventManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.FindOrAddJurisdiction(Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.FindOrAddJurisdiction(Is(_expectedSingleJurisdiction.Description)))
            .WasCalled(Times.Once);
    }
}
