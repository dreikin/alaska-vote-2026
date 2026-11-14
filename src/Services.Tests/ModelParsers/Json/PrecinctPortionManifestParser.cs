using System.Text;
using DataModel;
using DataModel.Constants;
using VoteRepository;

namespace Services.Tests.ModelParsers.Json;

public class PrecinctPortionManifestParser
{
    private const string SingleItemList = """
                                          {
                                              "Version": "5.17.18.1",
                                              "List": [
                                                  {
                                                      "Description": "01-600 Ketchikan No. 1",
                                                      "Id": 1,
                                                      "ExternalId": "01-600",
                                                      "PrecinctId": 1
                                                  },
                                              ]
                                          }
                                          """;

    private readonly PrecinctPortion _expectedSingle = new()
        { Description = "01-600 Ketchikan No. 1", Id = 1, ExternalId = "01-600", PrecinctId = 1 };

    [Test]
    public async Task Parse_Adds_TableVersion()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        var parser = new Services.ModelParsers.Json.PrecinctPortionManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddTableVersion(Any(), Any())).WasCalled(Times.Once);
        await Assert.That(repository.AddTableVersion(CollectionNames.PrecinctPortion, "5.17.18.1"))
            .WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_PrecinctPortion()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        var parser = new Services.ModelParsers.Json.PrecinctPortionManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddPrecinctPortion(Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.AddPrecinctPortion(Is<PrecinctPortion>(actual =>
                actual.Description == _expectedSingle.Description)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddPrecinctPortion(Is<PrecinctPortion>(actual => actual.Id == _expectedSingle.Id)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddPrecinctPortion(Is<PrecinctPortion>(actual =>
                actual.ExternalId == _expectedSingle.ExternalId)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddPrecinctPortion(Is<PrecinctPortion>(actual =>
                actual.PrecinctId == _expectedSingle.PrecinctId)))
            .WasCalled(Times.Once);
    }
}
