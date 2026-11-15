using System.Text;
using DataModel;
using DataModel.Constants;
using Repository;

namespace Services.Tests.ModelParsers.Json;

public class BallotTypeContestManifestParser
{
    private const string SingleItemList = """
                                          {
                                              "Version": "5.17.18.1",
                                              "List": [
                                                  {
                                                      "BallotTypeId": 1,
                                                      "ContestId": 6
                                                  },
                                              ]
                                          }
                                          """;

    private readonly BallotTypeContest _expectedSingle = new() { BallotTypeId = 1, ContestId = 6 };

    [Test]
    public async Task Parse_Adds_CollectionVersion()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        var parser = new Services.ModelParsers.Json.BallotTypeContestManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.FindOrAddCollectionVersion(Any(), Any())).WasCalled(Times.Once);
        await Assert.That(repository.FindOrAddCollectionVersion(CollectionNames.BallotTypeContest, "5.17.18.1"))
            .WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_BallotTypeContest()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        var parser = new Services.ModelParsers.Json.BallotTypeContestManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddBallotTypeContest(Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.AddBallotTypeContest(Is<BallotTypeContest>(actual =>
                actual.BallotTypeId == _expectedSingle.BallotTypeId)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddBallotTypeContest(Is<BallotTypeContest>(actual =>
                actual.ContestId == _expectedSingle.ContestId)))
            .WasCalled(Times.Once);
    }
}
