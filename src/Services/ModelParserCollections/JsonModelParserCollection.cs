using Services.Interfaces;
using Services.ModelParsers.Json;

namespace Services.ModelParserCollections;

public class JsonModelParserCollection : IModelParserCollection
{
    public IModelParser BallotTypeContestManifestParser { get; } = new BallotTypeContestManifestParser();
    public IModelParser BallotTypeManifestParser { get; } = new BallotTypeManifestParser();
    public IModelParser CandidateManifestParser { get; } = new CandidateManifestParser();
    public IModelParser ConfigurationParser { get; } = new ConfigurationParser();
    public IModelParser ContestManifestParser { get; } = new ContestManifestParser();
    public IModelParser CountingGroupManifestParser { get; } = new CountingGroupManifestParser();
    public IModelParser CvrParser { get; } = new CvrParser();
    public IModelParser DistrictManifestParser { get; } = new DistrictManifestParser();
    public IModelParser DistrictPrecinctPortionManifestParser { get; } = new DistrictPrecinctPortionManifestParser();
    public IModelParser DistrictTypeManifestParser { get; } = new DistrictTypeManifestParser();
    public IModelParser ElectionEventManifestParser { get; } = new ElectionEventManifestParser();
    public IModelParser OutstackConditionManifestParser { get; } = new OutstackConditionManifestParser();
    public IModelParser PartyManifestParser { get; } = new PartyManifestParser();
    public IModelParser PrecinctManifestParser { get; } = new PrecinctManifestParser();
    public IModelParser PrecinctPortionManifestParser { get; } = new PrecinctPortionManifestParser();
    public IModelParser TabulatorManifestParser { get; } = new TabulatorManifestParser();
}
