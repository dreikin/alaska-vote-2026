using Services.Interfaces;
using VoteRepository;

namespace Services.FileCollectionParsers;

public class JsonFileCollectionParser(IFileParserCollection fileParsers) : IFileCollectionParser
{
    private readonly List<(string file, IFileParser parser)> _manifestData =
    [
        ("BallotTypeContestManifest.json", fileParsers.BallotTypeContestManifestParser),
        ("BallotTypeManifest.json", fileParsers.BallotTypeManifestParser),
        ("CandidateManifest.json", fileParsers.CandidateManifestParser),
        ("Configuration.json", fileParsers.ConfigurationParser),
        ("ContestManifest.json", fileParsers.ContestManifestParser),
        ("CountingGroupManifest.json", fileParsers.CountingGroupManifestParser),
        ("DistrictManifest.json", fileParsers.DistrictManifestParser),
        ("DistrictPrecinctPortionManifest.json", fileParsers.DistrictPrecinctPortionManifestParser),
        ("DistrictTypeManifest.json", fileParsers.DistrictTypeManifestParser),
        ("ElectionEventManifest.json", fileParsers.ElectionEventManifestParser),
        ("OutstackConditionManifest.json", fileParsers.OutstackConditionManifestParser),
        ("PartyManifest.json", fileParsers.PartyManifestParser),
        ("PrecinctManifest.json", fileParsers.PrecinctManifestParser),
        ("PrecinctPortionManifest.json", fileParsers.PrecinctPortionManifestParser),
        ("TabulatorManifest.json", fileParsers.TabulatorManifestParser)
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
                await fileParsers.CvrParser.Parse(file, repository);
    }

    private async Task ParseManifestFiles(string folderPath, IVoteRepository repository)
    {
        foreach (var (file, parser) in _manifestData)
        {
            var path = Path.Combine(folderPath, file);
            await parser.Parse(path, repository);
        }
    }
}
