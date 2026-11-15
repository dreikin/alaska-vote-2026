using System.Text;
using DataModel;
using DataModel.Constants;
using Repository;

namespace Services.Tests.ModelParsers.Json;

public class TabulatorManifestParser
{
    private const string SingleItemList = """
                                          {
                                              "Version": "5.17.18.1",
                                              "List": [
                                                  {
                                                      "Description": "ICR",
                                                      "Id": 1000,
                                                      "VotingLocationNumber": 999,
                                                      "VotingLocationName": "Remote",
                                                      "ExternalId": "ICR",
                                                      "Type": "InternetVoting",
                                                      "ThresholdMin": 0,
                                                      "ThresholdMax": 0,
                                                      "WriteThresholdMin": 0,
                                                      "WriteThresholdMax": 0
                                                  },
                                              ]
                                          }
                                          """;

    private readonly Tabulator _expectedSingleTabulator = new()
    {
        Description = "ICR", Id = 1000, ExternalId = "ICR", VotingLocationId = 999, TabulatorTypeId = 5,
        ThresholdMin = 0, ThresholdMax = 0, WriteThresholdMin = 0, WriteThresholdMax = 0
    };

    [Test]
    public async Task Parse_Adds_CollectionVersion_For_Tabulator()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        repository.FindOrAddTabulatorType(Any()).ReturnsAsync(Task.FromResult(5));
        var parser = new Services.ModelParsers.Json.TabulatorManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.FindOrAddCollectionVersion(Any(), Any())).WasCalled(Times.Exactly(3));
        await Assert.That(repository.FindOrAddCollectionVersion(CollectionNames.Tabulator, "5.17.18.1"))
            .WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_CollectionVersion_For_TabulatorType()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        repository.FindOrAddTabulatorType(Any()).ReturnsAsync(Task.FromResult(5));
        var parser = new Services.ModelParsers.Json.TabulatorManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.FindOrAddCollectionVersion(Any(), Any())).WasCalled(Times.Exactly(3));
        await Assert.That(repository.FindOrAddCollectionVersion(CollectionNames.TabulatorType, "5.17.18.1"))
            .WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_CollectionVersion_For_VotingLocation()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        repository.FindOrAddTabulatorType(Any()).ReturnsAsync(Task.FromResult(5));
        var parser = new Services.ModelParsers.Json.TabulatorManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.FindOrAddCollectionVersion(Any(), Any())).WasCalled(Times.Exactly(3));
        await Assert.That(repository.FindOrAddCollectionVersion(CollectionNames.VotingLocation, "5.17.18.1"))
            .WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_Tabulator()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        repository.FindOrAddTabulatorType(Any()).ReturnsAsync(Task.FromResult(5));
        var parser = new Services.ModelParsers.Json.TabulatorManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddTabulator(Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.AddTabulator(Is<Tabulator>(actual =>
                actual.Description == _expectedSingleTabulator.Description)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddTabulator(Is<Tabulator>(actual => actual.Id == _expectedSingleTabulator.Id)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddTabulator(Is<Tabulator>(actual =>
                actual.ExternalId == _expectedSingleTabulator.ExternalId)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddTabulator(Is<Tabulator>(actual =>
                actual.VotingLocationId == _expectedSingleTabulator.VotingLocationId)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddTabulator(Is<Tabulator>(actual =>
                actual.TabulatorTypeId == _expectedSingleTabulator.TabulatorTypeId)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddTabulator(Is<Tabulator>(actual =>
                actual.ThresholdMin == _expectedSingleTabulator.ThresholdMin)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddTabulator(Is<Tabulator>(actual =>
                actual.ThresholdMax == _expectedSingleTabulator.ThresholdMax)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddTabulator(Is<Tabulator>(actual =>
                actual.WriteThresholdMin == _expectedSingleTabulator.WriteThresholdMin)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddTabulator(Is<Tabulator>(actual =>
                actual.WriteThresholdMax == _expectedSingleTabulator.WriteThresholdMax)))
            .WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_TabulatorType()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        repository.FindOrAddTabulatorType(Any()).ReturnsAsync(Task.FromResult(5));
        var parser = new Services.ModelParsers.Json.TabulatorManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.FindOrAddTabulatorType(Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.FindOrAddTabulatorType(Is("InternetVoting")))
            .WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_VotingLocation()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        repository.FindOrAddTabulatorType(Any()).ReturnsAsync(Task.FromResult(5));
        var parser = new Services.ModelParsers.Json.TabulatorManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddVotingLocation(Any(), Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.AddVotingLocation(Is(999), Is("Remote")))
            .WasCalled(Times.Once);
    }
}
