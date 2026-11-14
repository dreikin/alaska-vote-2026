using Services.FileParsers.Json;
using Services.Interfaces;

namespace Services.FileParserCollections;

public class JsonFileParserCollection : IFileParserCollection
{
    public IFileParser BallotTypeContestManifestParser { get; } = new BallotTypeContestManifestParser();
    public IFileParser BallotTypeManifestParser { get; } = new BallotTypeManifestParser();
    public IFileParser CandidateManifestParser { get; } = new CandidateManifestParser();
    public IFileParser ConfigurationParser { get; } = new ConfigurationParser();
    public IFileParser ContestManifestParser { get; } = new ContestManifestParser();
    public IFileParser CountingGroupManifestParser { get; } = new CountingGroupManifestParser();
    public IFileParser CvrParser { get; } = new CvrParser();
    public IFileParser DistrictManifestParser { get; } = new DistrictManifestParser();
    public IFileParser DistrictPrecinctPortionManifestParser { get; } = new DistrictPrecinctPortionManifestParser();
    public IFileParser DistrictTypeManifestParser { get; } = new DistrictTypeManifestParser();
    public IFileParser ElectionEventManifestParser { get; } = new ElectionEventManifestParser();
    public IFileParser OutstackConditionManifestParser { get; } = new OutstackConditionManifestParser();
    public IFileParser PartyManifestParser { get; } = new PartyManifestParser();
    public IFileParser PrecinctManifestParser { get; } = new PrecinctManifestParser();
    public IFileParser PrecinctPortionManifestParser { get; } = new PrecinctPortionManifestParser();
    public IFileParser TabulatorManifestParser { get; } = new TabulatorManifestParser();
}
