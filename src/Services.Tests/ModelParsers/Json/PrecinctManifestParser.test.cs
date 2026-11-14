using System.Text;
using DataModel;
using DataModel.Constants;
using VoteRepository;

namespace Services.Tests.ModelParsers.Json;

public class PrecinctManifestParser
{
    private const string SingleItemList = """
                                          {
                                          "Version": "5.17.18.1",
                                              "List": [
                                                  {
                                                      "Description": "01-600 Ketchikan No. 1",
                                                      "Id": 1,
                                                      "ExternalId": "01-600"
                                                  },
                                              ]
                                          }
                                          """;

    private readonly Precinct _expectedSingle = new()
        { Description = "01-600 Ketchikan No. 1", Id = 1, ExternalId = "01-600" };

    [Test]
    public async Task Parse_Adds_TableVersion()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        var parser = new Services.ModelParsers.Json.PrecinctManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddTableVersion(Any(), Any())).WasCalled(Times.Once);
        await Assert.That(repository.AddTableVersion(CollectionNames.Precinct, "5.17.18.1"))
            .WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_Precinct()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        var parser = new Services.ModelParsers.Json.PrecinctManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddPrecinct(Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.AddPrecinct(Is<Precinct>(actual =>
                actual.Description == _expectedSingle.Description)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddPrecinct(Is<Precinct>(actual => actual.Id == _expectedSingle.Id)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddPrecinct(Is<Precinct>(actual => actual.ExternalId == _expectedSingle.ExternalId)))
            .WasCalled(Times.Once);
    }
}
