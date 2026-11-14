namespace Services.Interfaces;

public interface IFileParserCollection
{
    IFileParser BallotTypeContestManifestParser { get; }
    IFileParser BallotTypeManifestParser { get; }
    IFileParser CandidateManifestParser { get; }
    IFileParser ConfigurationParser { get; }
    IFileParser ContestManifestParser { get; }
    IFileParser CountingGroupManifestParser { get; }
    IFileParser CvrParser { get; }
    IFileParser DistrictManifestParser { get; }
    IFileParser DistrictPrecinctPortionManifestParser { get; }
    IFileParser DistrictTypeManifestParser { get; }
    IFileParser ElectionEventManifestParser { get; }
    IFileParser OutstackConditionManifestParser { get; }
    IFileParser PartyManifestParser { get; }
    IFileParser PrecinctManifestParser { get; }
    IFileParser PrecinctPortionManifestParser { get; }
    IFileParser TabulatorManifestParser { get; }
}
