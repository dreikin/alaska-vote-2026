using System.Text;
using DataModel;
using DataModel.Constants;
using Repository;

namespace Services.Tests.ModelParsers.Json;

public class DistrictTypeManifestParser
{
    private const string SingleItemList = """
                                          {
                                              "Version": "5.17.18.1",
                                              "List": [
                                                  {
                                                      "Description": "State",
                                                      "Id": "32cb037e-e3da-4a88-a65c-6cfa2089c806",
                                                      "ExternalId": ""
                                                  },
                                              ]
                                          }
                                          """;

    private readonly DistrictType _expectedSingle = new()
        { Description = "State", Id = new Guid("32cb037e-e3da-4a88-a65c-6cfa2089c806"), ExternalId = "" };

    [Test]
    public async Task Parse_Adds_CollectionVersion()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        var parser = new Services.ModelParsers.Json.DistrictTypeManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.FindOrAddCollectionVersion(Any(), Any())).WasCalled(Times.Once);
        await Assert.That(repository.FindOrAddCollectionVersion(CollectionNames.DistrictType, "5.17.18.1"))
            .WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_DistrictType()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        var parser = new Services.ModelParsers.Json.DistrictTypeManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddDistrictType(Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.AddDistrictType(Is<DistrictType>(actual =>
                actual.Description == _expectedSingle.Description)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddDistrictType(Is<DistrictType>(actual => actual.Id == _expectedSingle.Id)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddDistrictType(Is<DistrictType>(actual =>
                actual.ExternalId == _expectedSingle.ExternalId)))
            .WasCalled(Times.Once);
    }
}
