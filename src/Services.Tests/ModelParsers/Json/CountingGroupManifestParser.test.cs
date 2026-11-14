using System.Text;
using DataModel;
using DataModel.Constants;
using VoteRepository;

namespace Services.Tests.ModelParsers.Json;

public class CountingGroupManifestParser
{
    private const string SingleItemList = """
                                          {
                                              "Version": "5.17.18.1",
                                              "List": [
                                                  {
                                                      "Description": "Election Day",
                                                      "Id": 1,
                                                      "ExternalId": ""
                                                  },
                                              ]
                                          }
                                          """;

    private readonly CountingGroup _expectedSingle = new() { Description = "Election Day", Id = 1, ExternalId = "" };

    [Test]
    public async Task Parse_AddsTableVersion()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        var parser = new Services.ModelParsers.Json.CountingGroupManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddTableVersion(Any(), Any())).WasCalled(Times.Once);
        await Assert.That(repository.AddTableVersion(CollectionNames.CountingGroup, "5.17.18.1")).WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_AddsTableBallotType()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        var parser = new Services.ModelParsers.Json.CountingGroupManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddCountingGroup(Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.AddCountingGroup(Is<CountingGroup>(actual =>
                actual.Description == _expectedSingle.Description)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddCountingGroup(Is<CountingGroup>(actual => actual.Id == _expectedSingle.Id)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddCountingGroup(Is<CountingGroup>(actual =>
                actual.ExternalId == _expectedSingle.ExternalId)))
            .WasCalled(Times.Once);
    }
}
