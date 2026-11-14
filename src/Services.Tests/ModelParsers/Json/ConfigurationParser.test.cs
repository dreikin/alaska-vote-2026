using System.Text;
using DataModel;
using VoteRepository;

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
    public async Task Parse_Adds_CountingGroup()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(SingleItemList));
        var repository = IVoteRepository.Mock();
        var parser = new Services.ModelParsers.Json.ConfigurationParser();

        await parser.Parse(stream, repository);

        await Assert.That(repository.SetConfiguration(Any())).WasCalled(Times.Once);
        await Assert
            .That(repository.SetConfiguration(Is<Configuration>(actual =>
                actual.IncludeTabulatorFilter == _expected.IncludeTabulatorFilter)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.SetConfiguration(Is<Configuration>(actual =>
                actual.TabulatorFilterValue == _expected.TabulatorFilterValue)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.SetConfiguration(Is<Configuration>(actual =>
                actual.IncludeResultContainerFilter == _expected.IncludeResultContainerFilter)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.SetConfiguration(Is<Configuration>(actual =>
                actual.ResultContainerFilterValue == _expected.ResultContainerFilterValue)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.SetConfiguration(Is<Configuration>(actual =>
                actual.IncludeBallotTypeFilter == _expected.IncludeBallotTypeFilter)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.SetConfiguration(Is<Configuration>(actual => actual.ContestFilter.Count == 0)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.SetConfiguration(Is<Configuration>(actual => actual.PrecinctPortionFilter.Count == 0)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.SetConfiguration(Is<Configuration>(actual =>
                actual.SplitFilesPerBatch == _expected.SplitFilesPerBatch)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.SetConfiguration(Is<Configuration>(actual =>
                actual.IncludeOnlyPublishedResultContainers == _expected.IncludeOnlyPublishedResultContainers)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.SetConfiguration(Is<Configuration>(actual =>
                actual.UseTabulatorFormat == _expected.UseTabulatorFormat)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.SetConfiguration(Is<Configuration>(actual =>
                actual.IncludeSessionDetails == _expected.IncludeSessionDetails)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.SetConfiguration(Is<Configuration>(actual =>
                actual.IncludeMarkDensity == _expected.IncludeMarkDensity)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.SetConfiguration(Is<Configuration>(actual => actual.CvrType == _expected.CvrType)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.SetConfiguration(Is<Configuration>(actual =>
                actual.CvrTurnoutTest == _expected.CvrTurnoutTest)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.SetConfiguration(Is<Configuration>(actual =>
                actual.CvrSuppressionType == _expected.CvrSuppressionType)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.SetConfiguration(Is<Configuration>(actual =>
                actual.TurnoutThreshold == _expected.TurnoutThreshold)))
            .WasCalled(Times.Once);
        await Assert
            .That(repository.SetConfiguration(Is<Configuration>(actual => actual.OutstackConditions.Count == 0)))
            .WasCalled(Times.Once);
    }
}
