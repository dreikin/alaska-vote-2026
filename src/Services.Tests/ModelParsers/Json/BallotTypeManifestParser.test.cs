using System.Text;
using DataModel;
using DataModel.Constants;
using Repository;

namespace Services.Tests.ModelParsers.Json;

public class BallotTypeManifestParser
{
    private const string SingleItemList = """
                                          {
                                              "Version": "5.17.18.1",
                                              "List": [
                                                  {
                                                      "Description": "Ballot 1 - Type 1",
                                                      "Id": 1,
                                                      "ExternalId": ""
                                                  },
                                              ]
                                          }
                                          """;

    private readonly BallotType _expectedSingle = new() { Description = "Ballot 1 - Type 1", Id = 1, ExternalId = "" };

    [Test]
    public async Task Parse_Adds_CollectionVersion()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        var parser = new Services.ModelParsers.Json.BallotTypeManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.FindOrAddCollectionVersion(Any(), Any())).WasCalled(Times.Once);
        await Assert.That(repository.FindOrAddCollectionVersion(CollectionNames.BallotType, "5.17.18.1"))
            .WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_BallotType()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        var parser = new Services.ModelParsers.Json.BallotTypeManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.FindOrAddBallotType(Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.FindOrAddBallotType(Is<BallotType>(actual => actual.Description == _expectedSingle.Description)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.FindOrAddBallotType(Is<BallotType>(actual => actual.Id == _expectedSingle.Id)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.FindOrAddBallotType(Is<BallotType>(actual => actual.ExternalId == _expectedSingle.ExternalId)))
            .WasCalled(Times.Once);
    }
}
