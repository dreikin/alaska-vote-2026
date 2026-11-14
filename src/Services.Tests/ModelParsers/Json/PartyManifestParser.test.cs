using System.Text;
using DataModel;
using DataModel.Constants;
using VoteRepository;

namespace Services.Tests.ModelParsers.Json;

public class PartyManifestParser
{
    private const string SingleItemList = """
                                          {
                                              "Version": "5.17.18.1",
                                              "List": [
                                                  {
                                                      "Description": "Nonpartisan",
                                                      "Id": 1,
                                                      "ExternalId": ""
                                                  },
                                              ]
                                          }
                                          """;

    private readonly Party _expectedSingle = new()
        { Description = "Nonpartisan", Id = 1, ExternalId = "" };

    [Test]
    public async Task Parse_Adds_TableVersion()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        var parser = new Services.ModelParsers.Json.PartyManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddTableVersion(Any(), Any())).WasCalled(Times.Once);
        await Assert.That(repository.AddTableVersion(CollectionNames.Party, "5.17.18.1"))
            .WasCalled(Times.Once);
    }

    [Test]
    public async Task Parse_Adds_Party()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        var parser = new Services.ModelParsers.Json.PartyManifestParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.AddParty(Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.AddParty(Is<Party>(actual =>
                actual.Description == _expectedSingle.Description)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddParty(Is<Party>(actual => actual.Id == _expectedSingle.Id)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.AddParty(Is<Party>(actual => actual.ExternalId == _expectedSingle.ExternalId)))
            .WasCalled(Times.Once);
    }
}
