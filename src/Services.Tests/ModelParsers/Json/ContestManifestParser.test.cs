using System.Text;
using DataModel;
using DataModel.Constants;
using Repository;

namespace Services.Tests.ModelParsers.Json;

public class ContestManifestParser
{
    private const string SingleItemList = """
                                          {
                                              "Version": "5.17.18.1",
                                              "List": [
                                                  {
                                                      "Description": "U.S. Senator",
                                                      "Id": 6,
                                                      "ExternalId": "",
                                                      "DistrictId": 67,
                                                      "VoteFor": 1,
                                                      "NumOfRanks": 5,
                                                      "NumOfWriteins": 1,
                                                      "Disabled": 0,
                                                      "Type": "Candidacy"
                                                  },
                                              ]
                                          }
                                          """;

    private readonly Contest _expectedSingle = new()
    {
        Description = "U.S. Senator", Id = 6, ExternalId = "", DistrictId = 67, VoteFor = 1, NumOfRanks = 5,
        NumOfWriteins = 1, Disabled = false, ContestTypeId = 4
    };

    [Test]
    public async Task Parse_Adds_CollectionVersion_For_Contest()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        repository.FindOrAddContestType(Any()).ReturnsAsync(Task.FromResult(_expectedSingle.ContestTypeId));
        var parser = new Services.ModelParsers.Json.ContestManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.FindOrAddCollectionVersion(Any(), Any())).WasCalled(Times.Exactly(2));
        await Assert.That(repository.FindOrAddCollectionVersion(CollectionNames.Contest, "5.17.18.1")).WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_CollectionVersion_For_ContestType()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        repository.FindOrAddContestType(Any()).ReturnsAsync(Task.FromResult(_expectedSingle.ContestTypeId));
        var parser = new Services.ModelParsers.Json.ContestManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.FindOrAddCollectionVersion(Any(), Any())).WasCalled(Times.Exactly(2));
        await Assert.That(repository.FindOrAddCollectionVersion(CollectionNames.ContestType, "5.17.18.1"))
            .WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_Contest()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        repository.FindOrAddContestType(Any()).ReturnsAsync(Task.FromResult(_expectedSingle.ContestTypeId));
        var parser = new Services.ModelParsers.Json.ContestManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddContest(Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.AddContest(Is<Contest>(actual =>
                actual.Description == _expectedSingle.Description)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddContest(Is<Contest>(actual => actual.Id == _expectedSingle.Id)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddContest(Is<Contest>(actual =>
                actual.ExternalId == _expectedSingle.ExternalId)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddContest(Is<Contest>(actual =>
                actual.DistrictId == _expectedSingle.DistrictId)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddContest(Is<Contest>(actual =>
                actual.VoteFor == _expectedSingle.VoteFor)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddContest(Is<Contest>(actual =>
                actual.NumOfRanks == _expectedSingle.NumOfRanks)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddContest(Is<Contest>(actual =>
                actual.NumOfWriteins == _expectedSingle.NumOfWriteins)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddContest(Is<Contest>(actual =>
                actual.Disabled == _expectedSingle.Disabled)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddContest(Is<Contest>(actual =>
                actual.ContestTypeId == _expectedSingle.ContestTypeId)))
            .WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_ContestType()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        repository.FindOrAddContestType(Any()).ReturnsAsync(Task.FromResult(_expectedSingle.ContestTypeId));
        var parser = new Services.ModelParsers.Json.ContestManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.FindOrAddContestType(Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.FindOrAddContestType(Is(@"Candidacy")))
            .WasCalled(Times.Once);
    }
}
