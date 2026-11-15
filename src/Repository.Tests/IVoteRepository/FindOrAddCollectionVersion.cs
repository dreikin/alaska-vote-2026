namespace Repository.Tests.IVoteRepository;

public class FindOrAddCollectionVersion
{
    [Test]
    [MethodDataSource(typeof(ImplementationDataSource), nameof(ImplementationDataSource.Repositories))]
    public async Task ReturnsTheId_OfA_NewRow(RepositoryType repositoryType)
    {
        await using var repo = ImplementationDataSource.GetRepository(repositoryType);
        var id = await repo.FindOrAddCollectionVersion("Test", "10");

        await Assert.That(id).IsEqualTo(1);
    }

    [Test]
    [MethodDataSource(typeof(ImplementationDataSource), nameof(ImplementationDataSource.Repositories))]
    public async Task ReturnsTheId_OfA_PreviouslyAddedRow(RepositoryType repositoryType)
    {
        await using var repo = ImplementationDataSource.GetRepository(repositoryType);
        await repo.FindOrAddCollectionVersion("Test", "10");
        await repo.FindOrAddCollectionVersion("Test", "20");
        var id = await repo.FindOrAddCollectionVersion("Test", "20");

        await Assert.That(id).IsEqualTo(2);
    }
}
