using Services.Interfaces;
using Services.Interfaces.Json;
using Services.ModelParsers.Json;

namespace Services.ModelParserCollections;

public class JsonModelParserCollection : IJsonModelParserCollection
{
    public IJsonModelParser BallotTypeContestManifestParser { get; } = new BallotTypeContestManifestParser();
    public IJsonModelParser BallotTypeManifestParser { get; } = new BallotTypeManifestParser();
    public IJsonModelParser CandidateManifestParser { get; } = new CandidateManifestParser();
    public IJsonModelParser ConfigurationParser { get; } = new ConfigurationParser();
    public IJsonModelParser ContestManifestParser { get; } = new ContestManifestParser();
    public IJsonModelParser CountingGroupManifestParser { get; } = new CountingGroupManifestParser();
    public IJsonModelParser VotingRecordParser { get; } = new VotingRecordParser();
    public IJsonModelParser DistrictManifestParser { get; } = new DistrictManifestParser();

    public IJsonModelParser DistrictPrecinctPortionManifestParser { get; } =
        new DistrictPrecinctPortionManifestParser();

    public IJsonModelParser DistrictTypeManifestParser { get; } = new DistrictTypeManifestParser();
    public IJsonModelParser ElectionEventManifestParser { get; } = new ElectionEventManifestParser();
    public IJsonModelParser OutstackConditionManifestParser { get; } = new OutstackConditionManifestParser();
    public IJsonModelParser PartyManifestParser { get; } = new PartyManifestParser();
    public IJsonModelParser PrecinctManifestParser { get; } = new PrecinctManifestParser();
    public IJsonModelParser PrecinctPortionManifestParser { get; } = new PrecinctPortionManifestParser();
    public IJsonModelParser TabulatorManifestParser { get; } = new TabulatorManifestParser();

    IModelParser IModelParserCollection.BallotTypeManifestParser => BallotTypeManifestParser;
    IModelParser IModelParserCollection.CandidateManifestParser => CandidateManifestParser;
    IModelParser IModelParserCollection.ConfigurationParser => ConfigurationParser;
    IModelParser IModelParserCollection.ContestManifestParser => ContestManifestParser;
    IModelParser IModelParserCollection.CountingGroupManifestParser => CountingGroupManifestParser;
    IModelParser IModelParserCollection.VotingRecordParser => VotingRecordParser;
    IModelParser IModelParserCollection.DistrictManifestParser => DistrictManifestParser;
    IModelParser IModelParserCollection.DistrictPrecinctPortionManifestParser => DistrictPrecinctPortionManifestParser;
    IModelParser IModelParserCollection.DistrictTypeManifestParser => DistrictTypeManifestParser;
    IModelParser IModelParserCollection.ElectionEventManifestParser => ElectionEventManifestParser;
    IModelParser IModelParserCollection.OutstackConditionManifestParser => OutstackConditionManifestParser;
    IModelParser IModelParserCollection.PartyManifestParser => PartyManifestParser;
    IModelParser IModelParserCollection.PrecinctManifestParser => PrecinctManifestParser;
    IModelParser IModelParserCollection.PrecinctPortionManifestParser => PrecinctPortionManifestParser;
    IModelParser IModelParserCollection.TabulatorManifestParser => TabulatorManifestParser;
    IModelParser IModelParserCollection.BallotTypeContestManifestParser => BallotTypeContestManifestParser;
}
