namespace Services.Interfaces;

public interface IModelParserCollection
{
    IModelParser BallotTypeContestManifestParser { get; }
    IModelParser BallotTypeManifestParser { get; }
    IModelParser CandidateManifestParser { get; }
    IModelParser ConfigurationParser { get; }
    IModelParser ContestManifestParser { get; }
    IModelParser CountingGroupManifestParser { get; }
    IModelParser CvrParser { get; }
    IModelParser DistrictManifestParser { get; }
    IModelParser DistrictPrecinctPortionManifestParser { get; }
    IModelParser DistrictTypeManifestParser { get; }
    IModelParser ElectionEventManifestParser { get; }
    IModelParser OutstackConditionManifestParser { get; }
    IModelParser PartyManifestParser { get; }
    IModelParser PrecinctManifestParser { get; }
    IModelParser PrecinctPortionManifestParser { get; }
    IModelParser TabulatorManifestParser { get; }
}
