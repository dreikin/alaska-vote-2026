using Services.Interfaces;
using Services.Interfaces.Json;
using VoteRepository;

namespace Services.ModelCollectionParsers;

public class JsonModelCollectionParser(IJsonModelParserCollection modelParsers) : IModelCollectionParser
{
    private readonly List<(string file, IJsonModelParser parser)> _manifestData =
    [
        ("BallotTypeContestManifest.json", modelParsers.BallotTypeContestManifestParser),
        ("BallotTypeManifest.json", modelParsers.BallotTypeManifestParser),
        ("CandidateManifest.json", modelParsers.CandidateManifestParser),
        ("Configuration.json", modelParsers.ConfigurationParser),
        ("ContestManifest.json", modelParsers.ContestManifestParser),
        ("CountingGroupManifest.json", modelParsers.CountingGroupManifestParser),
        ("DistrictManifest.json", modelParsers.DistrictManifestParser),
        ("DistrictPrecinctPortionManifest.json", modelParsers.DistrictPrecinctPortionManifestParser),
        ("DistrictTypeManifest.json", modelParsers.DistrictTypeManifestParser),
        ("ElectionEventManifest.json", modelParsers.ElectionEventManifestParser),
        ("OutstackConditionManifest.json", modelParsers.OutstackConditionManifestParser),
        ("PartyManifest.json", modelParsers.PartyManifestParser),
        ("PrecinctManifest.json", modelParsers.PrecinctManifestParser),
        ("PrecinctPortionManifest.json", modelParsers.PrecinctPortionManifestParser),
        ("TabulatorManifest.json", modelParsers.TabulatorManifestParser)
    ];

    /// <summary>
    ///     Opens a folder, parses the files inside, and adds the data to the repository.  This parser expects the folder to
    ///     have files with certain names or name patterns, all at the top level. If you need to parse a different
    ///     structure, you'll have to compose your own folder parser using the individual components.
    /// </summary>
    /// <param name="folderPath">The folder containing the files to be parsed.</param>
    /// <param name="repository">The repository to add the data to.</param>
    public async Task ParseFolder(string folderPath, IVoteRepository repository)
    {
        await ParseManifestFiles(folderPath, repository);
        await ParseCvrFiles(folderPath, repository);
    }

    private async Task ParseCvrFiles(string folderPath, IVoteRepository repository)
    {
        foreach (var file in Directory.EnumerateFiles(folderPath))
            if (file.StartsWith("CvrExport_") && file.EndsWith(".json"))
                await modelParsers.CvrParser.Parse(File.OpenRead(file), repository);
    }

    private async Task ParseManifestFiles(string folderPath, IVoteRepository repository)
    {
        foreach (var (file, parser) in _manifestData)
        {
            var path = Path.Combine(folderPath, file);
            var stream = File.OpenRead(path);
            await parser.Parse(stream, repository);
        }
    }
}
