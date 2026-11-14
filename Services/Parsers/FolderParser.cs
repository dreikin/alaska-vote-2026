using VoteRepository;

namespace Services.Parsers;

public static class FolderParser
{
    private static readonly List<(string file, Func<string, IVoteRepository, Task> parser)> ManifestFiles =
    [
        ("BallotTypeContestManifest.json", BallotTypeContestParser.Parse),
        ("BallotTypeManifest.json", BallotTypeParser.Parse),
        ("CandidateManifest.json", CandidateParser.Parse),
        ("Configuration.json", ConfigurationParser.Parse),
        ("ContestManifest.json", ContestParser.Parse),
        ("CountingGroupManifest.json", CountingGroupParser.Parse),
        ("DistrictManifest.json", DistrictParser.Parse),
        ("DistrictPrecinctPortionManifest.json", DistrictPrecinctPortionParser.Parse),
        ("DistrictTypeManifest.json", DistrictTypeParser.Parse),
        ("ElectionEventManifest.json", ElectionEventParser.Parse),
        ("OutstackConditionManifest.json", OutstackConditionParser.Parse),
        ("PartyManifest.json", PartyParser.Parse),
        ("PrecinctManifest.json", PrecinctParser.Parse),
        ("PrecinctPortionManifest.json", PrecinctPortionParser.Parse),
        ("TabulatorManifest.json", TabulatorParser.Parse)
    ];

    /// <summary>
    ///     Opens a folder, parses the files inside, and adds the data to the repository.  This parser expects the folder to
    ///     have files with certain names or name patterns, all at the top level. If you need to parse a different
    ///     structure, you'll have to compose your own folder parser using the individual components.
    /// </summary>
    /// <param name="folderPath">The folder containing the files to be parsed.</param>
    /// <param name="repository">The repository to add the data to.</param>
    public static async Task Parse(string folderPath, IVoteRepository repository)
    {
        await ParseManifestFiles(folderPath, repository);
        await ParseCvrFiles(folderPath, repository);
    }

    private static async Task ParseCvrFiles(string folderPath, IVoteRepository repository)
    {
        foreach (var file in Directory.EnumerateFiles(folderPath))
            if (file.StartsWith("CvrExport_") && file.EndsWith(".json"))
                await CvrParser.Parse(file, repository);
    }

    private static async Task ParseManifestFiles(string folderPath, IVoteRepository repository)
    {
        foreach (var manifestFile in ManifestFiles)
        {
            var path = Path.Combine(folderPath, manifestFile);
        }

        throw new NotImplementedException();
    }
}
