using System.Text;
using DataModel;
using Repository;

namespace Services.Tests.ModelParsers.Json;

public class ConfigurationParser
{
    private const string SingleItemList = """
                                          {
                                              "IncludeTabulatorFilter": false,
                                              "TabulatorFilterValue": 0,
                                              "IncludeResultContainerFilter": false,
                                              "ResultContainerFilterValue": 0,
                                              "IncludeBallotTypeFilter": false,
                                              "BallotTypeFilterValue": 0,
                                              "ContestFilter": [],
                                              "PrecinctPortionFilter": [],
                                              "SplitFilesPerBatch": true,
                                              "IncludeOnlyPublishedResultContainers": true,
                                              "UseTabulatorFormat": false,
                                              "IncludeSessionDetails": true,
                                              "IncludeMarkDensity": true,
                                              "CvrType": 0,
                                              "CvrTurnoutTest": 0,
                                              "CvrSuppressionType": 0,
                                              "TurnoutThreshold": 0,
                                              "OutstackConditions": []
                                          }
                                          """;

    private readonly Configuration _expected = new()
    {
        IncludeTabulatorFilter = false,
        TabulatorFilterValue = 0,
        IncludeResultContainerFilter = false,
        ResultContainerFilterValue = 0,
        IncludeBallotTypeFilter = false,
        BallotTypeFilterValue = 0,
        ContestFilter = new List<ContestFilter>(),
        PrecinctPortionFilter = new List<PrecinctPortionFilter>(),
        SplitFilesPerBatch = true,
        IncludeOnlyPublishedResultContainers = true,
        UseTabulatorFormat = false,
        IncludeSessionDetails = true,
        IncludeMarkDensity = true,
        CvrType = 0,
        CvrTurnoutTest = 0,
        CvrSuppressionType = 0,
        TurnoutThreshold = 0,
        OutstackConditions = new List<OutstackCondition>()
    };

    [Test]
    public async Task Parse_Adds_Configuration()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        var parser = new Services.ModelParsers.Json.ConfigurationParser();
        var comparer = new ConfigurationValueEqualityComparer();

        await parser.Parse(stream, repository);

        await Assert.That(repository.SetConfiguration(Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.SetConfiguration(Is<Configuration>(actual =>
                comparer.Equals(actual, _expected))))
            .WasCalled(Times.Once);
    }
}
