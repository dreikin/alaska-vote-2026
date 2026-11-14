namespace Services.Interfaces.Json;

public interface IJsonModelParserCollection : IModelParserCollection
{
    new IJsonModelParser BallotTypeContestManifestParser { get; }
    new IJsonModelParser BallotTypeManifestParser { get; }
    new IJsonModelParser CandidateManifestParser { get; }
    new IJsonModelParser ConfigurationParser { get; }
    new IJsonModelParser ContestManifestParser { get; }
    new IJsonModelParser CountingGroupManifestParser { get; }
    new IJsonModelParser VotingRecordParser { get; }
    new IJsonModelParser DistrictManifestParser { get; }
    new IJsonModelParser DistrictPrecinctPortionManifestParser { get; }
    new IJsonModelParser DistrictTypeManifestParser { get; }
    new IJsonModelParser ElectionEventManifestParser { get; }
    new IJsonModelParser OutstackConditionManifestParser { get; }
    new IJsonModelParser PartyManifestParser { get; }
    new IJsonModelParser PrecinctManifestParser { get; }
    new IJsonModelParser PrecinctPortionManifestParser { get; }
    new IJsonModelParser TabulatorManifestParser { get; }
}
