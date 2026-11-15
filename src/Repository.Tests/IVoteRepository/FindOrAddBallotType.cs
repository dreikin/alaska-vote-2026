using DataModel;
using Repository.Exceptions;

namespace Repository.Tests.IVoteRepository;

public class FindOrAddBallotType
{
    [Test]
    [MethodDataSource(typeof(ImplementationDataSource), nameof(ImplementationDataSource.Repositories))]
    [DisplayName("Returns the ID of a new row without ID [$repoType]")]
    public async Task ReturnsTheId_OfA_NewRowWithoutId(RepositoryType repositoryType, string repoType)
    {
        await using var repo = ImplementationDataSource.GetRepository(repositoryType);
        var ballot = new BallotType { Description = "Type 1" };

        var id = await repo.FindOrAddBallotType(ballot);

        await Assert.That(id).IsEqualTo(1);
    }

    [Test]
    [MethodDataSource(typeof(ImplementationDataSource), nameof(ImplementationDataSource.Repositories))]
    [DisplayName("Returns the ID of a previously added row without ID [$repoType]")]
    public async Task ReturnsTheId_OfA_PreviouslyAddedRowWithoutId(RepositoryType repositoryType, string repoType)
    {
        await using var repo = ImplementationDataSource.GetRepository(repositoryType);
        var ballot1 = new BallotType { Description = "Type 1" };
        var ballot2 = new BallotType { Description = "Type 2" };

        await repo.FindOrAddBallotType(ballot1);
        await repo.FindOrAddBallotType(ballot2);
        var id = await repo.FindOrAddBallotType(ballot2);

        await Assert.That(id).IsEqualTo(2);
    }

    [Test]
    [MethodDataSource(typeof(ImplementationDataSource), nameof(ImplementationDataSource.Repositories))]
    [DisplayName("Returns the ID of a new row with ID [$repoType]")]
    public async Task ReturnsTheId_OfA_NewRowWithId(RepositoryType repositoryType, string repoType)
    {
        await using var repo = ImplementationDataSource.GetRepository(repositoryType);
        var ballot = new BallotType { Id = 1, Description = "Type 1" };

        var id = await repo.FindOrAddBallotType(ballot);

        await Assert.That(id).IsEqualTo(1);
    }

    [Test]
    [MethodDataSource(typeof(ImplementationDataSource), nameof(ImplementationDataSource.Repositories))]
    [DisplayName("Returns the ID of a previously added row with ID [$repoType]")]
    public async Task ReturnsTheId_OfA_PreviouslyAddedRowWithId(RepositoryType repositoryType, string repoType)
    {
        await using var repo = ImplementationDataSource.GetRepository(repositoryType);
        var ballot1 = new BallotType { Id = 1, Description = "Type 1" };
        var ballot2 = new BallotType { Id = 2, Description = "Type 2" };

        await repo.FindOrAddBallotType(ballot1);
        await repo.FindOrAddBallotType(ballot2);
        var id = await repo.FindOrAddBallotType(ballot2);

        await Assert.That(id).IsEqualTo(2);
    }

    [Test]
    [MethodDataSource(typeof(ImplementationDataSource), nameof(ImplementationDataSource.Repositories))]
    [DisplayName("Throws IdDescriptionConflictException given same ID but different description [$repoType]")]
    public async Task Throws_IdDescriptionConflictException_Given_SameID_DifferentDescription(
        RepositoryType repositoryType, string repoType)
    {
        await using var repo = ImplementationDataSource.GetRepository(repositoryType);
        var ballot1 = new BallotType { Id = 1, Description = "Type 1" };
        var ballot2 = new BallotType { Id = 1, Description = "Type 2" };

        await repo.FindOrAddBallotType(ballot1);

        // ReSharper disable once MoveLocalFunctionAfterJumpStatement
        // ReSharper disable once AccessToDisposedClosure
        async Task<int> Action()
        {
            return await repo.FindOrAddBallotType(ballot2);
        }

        await Assert.That((Func<Task<int>>)Action).ThrowsExactly<IdDescriptionConflictException>();
    }

    [Test]
    [MethodDataSource(typeof(ImplementationDataSource), nameof(ImplementationDataSource.Repositories))]
    [DisplayName("Throws IdDescriptionConflictException given different ID but same description [$repoType]")]
    public async Task Throws_IdDescriptionConflictException_Given_DifferentID_SameDescription(
        RepositoryType repositoryType, string repoType)
    {
        await using var repo = ImplementationDataSource.GetRepository(repositoryType);
        var ballot1 = new BallotType { Id = 1, Description = "Type 1" };
        var ballot2 = new BallotType { Id = 2, Description = "Type 1" };

        await repo.FindOrAddBallotType(ballot1);

        // ReSharper disable once MoveLocalFunctionAfterJumpStatement
        // ReSharper disable once AccessToDisposedClosure
        async Task<int> Action()
        {
            return await repo.FindOrAddBallotType(ballot2);
        }

        await Assert.That((Func<Task<int>>)Action).ThrowsExactly<IdDescriptionConflictException>();
    }
}
