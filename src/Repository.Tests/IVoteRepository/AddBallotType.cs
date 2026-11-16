using DataModel;
using Repository.Exceptions;
using Tests.Common;

namespace Repository.Tests.IVoteRepository;

public class AddBallotType
{
    [Test]
    [MethodDataSource(typeof(ImplementationDataSource), nameof(ImplementationDataSource.Repositories))]
    [DisplayName("Throws InvalidIdException when given a new row constructed without ID [$repoType]")]
    public async Task ThrowsInvalidId_GivenA_NewRowConstructedWithoutId(RepositoryType repositoryType, string repoType)
    {
        await using var repo = ImplementationDataSource.GetRepository(repositoryType);
        var ballot = new BallotType { Description = "Type 1" }; // Mocks.BallotType;

        // ReSharper disable once MoveLocalFunctionAfterJumpStatement
        // ReSharper disable once AccessToDisposedClosure
        async Task<int> Action()
        {
            return await repo.AddBallotType(ballot);
        }

        await Assert.That(Action()).ThrowsExactly<InvalidIdException>();
    }

    [Test]
    [MethodDataSource(typeof(ImplementationDataSource), nameof(ImplementationDataSource.Repositories))]
    [DisplayName("Throws InvalidIdException when given a previously added row without ID [$repoType]")]
    public async Task Throws_GivenA_PreviouslyAddedRowWithoutId(RepositoryType repositoryType, string repoType)
    {
        await using var repo = ImplementationDataSource.GetRepository(repositoryType);
        var ballot1 = Mocks.BallotType;
        var ballot2 = Mocks.BallotType;
        ballot2.Id = 0; // 0 is default value for field, equivalent to no ID.

        await repo.AddBallotType(ballot1);

        // ReSharper disable once MoveLocalFunctionAfterJumpStatement
        // ReSharper disable once AccessToDisposedClosure
        async Task<int> Action()
        {
            return await repo.AddBallotType(ballot2);
        }

        await Assert.That(Action()).ThrowsExactly<InvalidIdException>();
    }

    [Test]
    [MethodDataSource(typeof(ImplementationDataSource), nameof(ImplementationDataSource.Repositories))]
    [DisplayName("Returns the ID of a new row with ID [$repoType]")]
    public async Task ReturnsTheId_OfA_NewRowWithId(RepositoryType repositoryType, string repoType)
    {
        await using var repo = ImplementationDataSource.GetRepository(repositoryType);
        var ballot = Mocks.BallotType;

        var id = await repo.AddBallotType(ballot);

        await Assert.That(id).IsEqualTo(1);
    }

    [Test]
    [MethodDataSource(typeof(ImplementationDataSource), nameof(ImplementationDataSource.Repositories))]
    [DisplayName("Throws IdAlreadyInUseException given a previously added row with the same ID [$repoType]")]
    public async Task Throws_GivenA_PreviouslyAddedRowWithId(RepositoryType repositoryType, string repoType)
    {
        await using var repo = ImplementationDataSource.GetRepository(repositoryType);
        var ballot = Mocks.BallotType;

        await repo.AddBallotType(ballot);

        // ReSharper disable once MoveLocalFunctionAfterJumpStatement
        // ReSharper disable once AccessToDisposedClosure
        async Task<int> Action()
        {
            return await repo.AddBallotType(ballot.ShallowCopy());
        }

        await Assert.That(Action()).ThrowsExactly<IdAlreadyInUseException>();
    }

    [Test]
    [MethodDataSource(typeof(ImplementationDataSource), nameof(ImplementationDataSource.Repositories))]
    [DisplayName("Throws IdAlreadyInUseException given same ID but different description [$repoType]")]
    public async Task Throws_Given_SameID_DifferentDescription(
        RepositoryType repositoryType, string repoType)
    {
        await using var repo = ImplementationDataSource.GetRepository(repositoryType);
        var ballot1 = new BallotType { Id = 1, Description = "Type 1" };
        var ballot2 = new BallotType { Id = 1, Description = "Type 2" };

        await repo.AddBallotType(ballot1);

        // ReSharper disable once MoveLocalFunctionAfterJumpStatement
        // ReSharper disable once AccessToDisposedClosure
        async Task<int> Action()
        {
            return await repo.AddBallotType(ballot2);
        }

        await Assert.That((Func<Task<int>>)Action).ThrowsExactly<IdAlreadyInUseException>();
    }

    [Test]
    [MethodDataSource(typeof(ImplementationDataSource), nameof(ImplementationDataSource.Repositories))]
    [DisplayName("Throws DescriptionHasDifferentIdException given different ID but same description [$repoType]")]
    public async Task Throws_Given_DifferentID_SameDescription(
        RepositoryType repositoryType, string repoType)
    {
        await using var repo = ImplementationDataSource.GetRepository(repositoryType);
        var ballot1 = new BallotType { Id = 1, Description = "Type 1" };
        var ballot2 = new BallotType { Id = 2, Description = "Type 1" };

        await repo.AddBallotType(ballot1);

        // ReSharper disable once MoveLocalFunctionAfterJumpStatement
        // ReSharper disable once AccessToDisposedClosure
        async Task<int> Action()
        {
            return await repo.AddBallotType(ballot2);
        }

        await Assert.That((Func<Task<int>>)Action).ThrowsExactly<DescriptionHasDifferentIdException>();
    }
}
