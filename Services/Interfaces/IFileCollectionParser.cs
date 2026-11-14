using VoteRepository;

namespace Services.Interfaces;

public interface IFileCollectionParser
{
    Task ParseFolder(string folderPath, IVoteRepository repository);
}
