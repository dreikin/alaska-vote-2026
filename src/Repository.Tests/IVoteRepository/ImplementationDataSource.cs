using DB.EntityFramework;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Repository.EntityFramework;

namespace Repository.Tests.IVoteRepository;

public enum RepositoryType
{
    EntityFramework
}

public static class ImplementationDataSource
{
    public static IEnumerable<TestDataRow<RepositoryType>> Repositories()
    {
        // Repository.EntityFramework + DB.EntityFramework w/ in-memory DB.
        yield return new TestDataRow<RepositoryType>(RepositoryType.EntityFramework,
            "EntityFramework with in-memory SQLite database");
    }

    public static Repository.IVoteRepository GetRepository(RepositoryType repositoryType)
    {
        return repositoryType switch
        {
            RepositoryType.EntityFramework => EntityFrameworkRepository(),
            _ => throw new ArgumentOutOfRangeException(nameof(repositoryType), repositoryType,
                "Not a recognized repository type")
        };
    }

    private static VoteRepository EntityFrameworkRepository()
    {
        var connection = new SqliteConnection("Filename=:memory:"); // (@"Filename=C:\Temp\VoteRepository.temp.db");
        connection.Open();
        var options = new DbContextOptionsBuilder<VoteRepositoryContext>()
            .UseSqlite(connection, true)
            .Options;
        var context = new VoteRepositoryContext(options);
        var tables = context.Database.SqlQuery<string>($"SELECT name FROM sqlite_schema WHERE type='table'");
        if (tables.Any()) throw new InvalidOperationException($"Vote repository has tables ${tables}");
        if (!context.Database.EnsureCreated()) throw new InvalidOperationException("Cannot create a vote repository");

        return new VoteRepository(context, true);
    }
}
