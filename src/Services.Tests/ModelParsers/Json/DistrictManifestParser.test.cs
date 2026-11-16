using System.Text;
using DataModel;
using DataModel.Constants;
using Repository;

namespace Services.Tests.ModelParsers.Json;

public class DistrictManifestParser
{
    private const string SingleItemList = """
                                          {
                                              "Version": "5.17.18.1",
                                              "List": [
                                                  {
                                                      "Description": "State of Alaska",
                                                      "Id": 67,
                                                      "DistrictTypeId": "32cb037e-e3da-4a88-a65c-6cfa2089c806",
                                                      "ExternalId": ""
                                                  },
                                              ]
                                          }
                                          """;

    private readonly District _expectedSingle = new()
    {
        Description = "State of Alaska", Id = 67, DistrictTypeId = new Guid("32cb037e-e3da-4a88-a65c-6cfa2089c806"),
        ExternalId = ""
    };

    [Test]
    public async Task Parse_Adds_CollectionVersion()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        var parser = new Services.ModelParsers.Json.DistrictManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.FindOrAddCollectionVersion(Any(), Any())).WasCalled(Times.Once);
        await Assert.That(repository.FindOrAddCollectionVersion(CollectionNames.District, "5.17.18.1"))
            .WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_District()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        var parser = new Services.ModelParsers.Json.DistrictManifestParser();
        var comparer = new DistrictValueEqualityComparer();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddDistrict(Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.AddDistrict(Is<District>(actual =>
                comparer.Equals(actual, _expectedSingle))))
            .WasCalled(Times.Once);
    }
}
