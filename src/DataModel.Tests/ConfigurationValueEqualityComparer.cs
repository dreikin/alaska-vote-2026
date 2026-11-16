using System.Diagnostics.CodeAnalysis;

namespace DataModel.Tests;

internal class DerivedConfiguration : Configuration
{
    [SetsRequiredMembers]
    public DerivedConfiguration(Configuration configuration)
    {
        Id = configuration.Id;
        IncludeTabulatorFilter = configuration.IncludeTabulatorFilter;
        TabulatorFilterValue = configuration.TabulatorFilterValue;
        IncludeResultContainerFilter = configuration.IncludeResultContainerFilter;
        ResultContainerFilterValue = configuration.ResultContainerFilterValue;
        IncludeBallotTypeFilter = configuration.IncludeBallotTypeFilter;
        BallotTypeFilterValue = configuration.BallotTypeFilterValue;
        ContestFilter = configuration.ContestFilter;
        PrecinctPortionFilter = configuration.PrecinctPortionFilter;
        SplitFilesPerBatch = configuration.SplitFilesPerBatch;
        IncludeOnlyPublishedResultContainers = configuration.IncludeOnlyPublishedResultContainers;
        UseTabulatorFormat = configuration.UseTabulatorFormat;
        IncludeSessionDetails = configuration.IncludeSessionDetails;
        IncludeMarkDensity = configuration.IncludeMarkDensity;
        CvrType = configuration.CvrType;
        CvrTurnoutTest = configuration.CvrTurnoutTest;
        CvrSuppressionType = configuration.CvrSuppressionType;
        TurnoutThreshold = configuration.TurnoutThreshold;
        OutstackConditions = configuration.OutstackConditions;
    }
}

public class ConfigurationValueEqualityComparer
{
    [Test]
    public async Task ReturnsTrue_When_BothNull()
    {
        Configuration? a = null;
        Configuration? b = null;
        var comparer = new DataModel.ConfigurationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_SameObject()
    {
        var a = Mocks.Configuration;
        var comparer = new DataModel.ConfigurationValueEqualityComparer();

        var result = comparer.Equals(a, a);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsTrue_When_ValueFieldsAreEqual()
    {
        var a = Mocks.Configuration;
        var b = Mocks.Configuration;
        var comparer = new DataModel.ConfigurationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNull_RightIsNotNull()
    {
        Configuration? a = null;
        var b = Mocks.Configuration;
        var comparer = new DataModel.ConfigurationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_LeftIsNotNull_RightIsNull()
    {
        var a = Mocks.Configuration;
        Configuration? b = null;
        var comparer = new DataModel.ConfigurationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_DifferentTypes()
    {
        Configuration a = new DerivedConfiguration(Mocks.Configuration);
        var b = Mocks.Configuration;
        var comparer = new DataModel.ConfigurationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IdIsDifferent()
    {
        var a = Mocks.Configuration;
        var b = Mocks.Configuration;
        b.Id += 1;
        var comparer = new DataModel.ConfigurationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IncludeTabulatorFilterIsDifferent()
    {
        var a = Mocks.Configuration;
        var b = Mocks.Configuration;
        b.IncludeTabulatorFilter = !a.IncludeTabulatorFilter;
        var comparer = new DataModel.ConfigurationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_TabulatorFilterValueIsDifferent()
    {
        var a = Mocks.Configuration;
        var b = Mocks.Configuration;
        b.TabulatorFilterValue += 1;
        var comparer = new DataModel.ConfigurationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IncludeResultContainerFilterIsDifferent()
    {
        var a = Mocks.Configuration;
        var b = Mocks.Configuration;
        b.IncludeResultContainerFilter = !a.IncludeResultContainerFilter;
        var comparer = new DataModel.ConfigurationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_ResultContainerFilterValueIsDifferent()
    {
        var a = Mocks.Configuration;
        var b = Mocks.Configuration;
        b.ResultContainerFilterValue += 1;
        var comparer = new DataModel.ConfigurationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IncludeBallotTypeFilterIsDifferent()
    {
        var a = Mocks.Configuration;
        var b = Mocks.Configuration;
        b.IncludeBallotTypeFilter = !a.IncludeBallotTypeFilter;
        var comparer = new DataModel.ConfigurationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_BallotTypeFilterValueIsDifferent()
    {
        var a = Mocks.Configuration;
        var b = Mocks.Configuration;
        b.BallotTypeFilterValue += 1;
        var comparer = new DataModel.ConfigurationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_SplitFilesPerBatchIsDifferent()
    {
        var a = Mocks.Configuration;
        var b = Mocks.Configuration;
        b.SplitFilesPerBatch = !a.SplitFilesPerBatch;
        var comparer = new DataModel.ConfigurationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IncludeOnlyPublishedResultContainersIsDifferent()
    {
        var a = Mocks.Configuration;
        var b = Mocks.Configuration;
        b.IncludeOnlyPublishedResultContainers = !a.IncludeOnlyPublishedResultContainers;
        var comparer = new DataModel.ConfigurationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_UseTabulatorFormatIsDifferent()
    {
        var a = Mocks.Configuration;
        var b = Mocks.Configuration;
        b.UseTabulatorFormat = !a.UseTabulatorFormat;
        var comparer = new DataModel.ConfigurationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IncludeSessionDetailsIsDifferent()
    {
        var a = Mocks.Configuration;
        var b = Mocks.Configuration;
        b.IncludeSessionDetails = !a.IncludeSessionDetails;
        var comparer = new DataModel.ConfigurationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_IncludeMarkDensityIsDifferent()
    {
        var a = Mocks.Configuration;
        var b = Mocks.Configuration;
        b.IncludeMarkDensity = !a.IncludeMarkDensity;
        var comparer = new DataModel.ConfigurationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_CvrTypeIsDifferent()
    {
        var a = Mocks.Configuration;
        var b = Mocks.Configuration;
        b.CvrType += 1;
        var comparer = new DataModel.ConfigurationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_CvrTurnoutTestIsDifferent()
    {
        var a = Mocks.Configuration;
        var b = Mocks.Configuration;
        b.CvrTurnoutTest += 1;
        var comparer = new DataModel.ConfigurationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_CvrSuppressionTypeIsDifferent()
    {
        var a = Mocks.Configuration;
        var b = Mocks.Configuration;
        b.CvrSuppressionType += 1;
        var comparer = new DataModel.ConfigurationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task ReturnsFalse_When_TurnoutThresholdIsDifferent()
    {
        var a = Mocks.Configuration;
        var b = Mocks.Configuration;
        b.TurnoutThreshold += 1;
        var comparer = new DataModel.ConfigurationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Ignores_RefFields()
    {
        var a = Mocks.Configuration;
        var b = Mocks.Configuration;
        b.ContestFilter = new List<ContestFilter>([Mocks.ContestFilter]);
        b.PrecinctPortionFilter = new List<PrecinctPortionFilter>([Mocks.PrecinctPortionFilter]);
        b.OutstackConditions = new List<OutstackCondition>([Mocks.OutstackCondition]);
        var comparer = new DataModel.ConfigurationValueEqualityComparer();

        var result = comparer.Equals(a, b);

        await Assert.That(result).IsTrue();
    }
}
