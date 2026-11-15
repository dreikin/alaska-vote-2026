using Repository;

namespace Services.Interfaces;

public interface IModelCollectionParser
{
    Task ParseFolder(string folderPath, IVoteRepository repository);
}