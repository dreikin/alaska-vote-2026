using System.Text;
using DataModel;
using DataModel.Constants;
using Repository;

namespace Services.Tests.ModelParsers.Json;

public class OutstackConditionManifestParser
{
    private const string SingleItemList = """
                                          {
                                              "Version": "5.17.18.1",
                                              "List": [
                                                  {
                                                      "Description": "Ambiguous",
                                                      "Id": 0
                                                  },
                                              ]
                                          }
                                          """;

    private readonly OutstackCondition _expectedSingle = new()
        { Description = "Ambiguous", Id = 0 };

    [Test]
    public async Task Parse_Adds_CollectionVersion()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        var parser = new Services.ModelParsers.Json.OutstackConditionManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.FindOrAddCollectionVersion(Any(), Any())).WasCalled(Times.Once);
        await Assert.That(repository.FindOrAddCollectionVersion(CollectionNames.OutstackCondition, "5.17.18.1"))
            .WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_OutstackCondition()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        var parser = new Services.ModelParsers.Json.OutstackConditionManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddOutstackCondition(Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.AddOutstackCondition(Is<OutstackCondition>(actual =>
                actual.Description == _expectedSingle.Description)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddOutstackCondition(Is<OutstackCondition>(actual => actual.Id == _expectedSingle.Id)))
            .WasCalled(Times.Once);
    }
}
