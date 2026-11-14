using System.Text;
using DataModel;
using DataModel.Constants;
using VoteRepository;

namespace Services.Tests.ModelParsers.Json;

public class DistrictPrecinctPortionManifestParser
{
    private const string SingleItemList = """
                                          {
                                              "Version": "5.17.18.1",
                                              "List": [
                                                  {
                                                      "DistrictId": 67,
                                                      "PrecinctPortionId": 1
                                                  },
                                              ]
                                          }
                                          """;

    private readonly DistrictPrecinctPortion _expectedSingle = new()
    {
        DistrictId = 67, PrecinctPortionId = 1
    };

    [Test]
    public async Task Parse_Adds_TableVersion()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        var parser = new Services.ModelParsers.Json.DistrictPrecinctPortionManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddTableVersion(Any(), Any())).WasCalled(Times.Once);
        await Assert.That(repository.AddTableVersion(CollectionNames.DistrictPrecinctPortion, "5.17.18.1"))
            .WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_DistrictPrecinctPortion()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        var parser = new Services.ModelParsers.Json.DistrictPrecinctPortionManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddDistrictPrecinctPortion(Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.AddDistrictPrecinctPortion(Is<DistrictPrecinctPortion>(actual =>
                actual.DistrictId == _expectedSingle.DistrictId)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddDistrictPrecinctPortion(Is<DistrictPrecinctPortion>(actual =>
                actual.PrecinctPortionId == _expectedSingle.PrecinctPortionId)))
            .WasCalled(Times.Once);
    }
}
