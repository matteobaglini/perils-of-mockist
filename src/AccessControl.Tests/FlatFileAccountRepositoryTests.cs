using System;
using System.IO;
using AccessControl.App;
using Xunit;

namespace AccessControl.Tests;

public class FlatFileAccountRepositoryTests : AccountRepositoryContractTests
{
    protected override IAccountRepository CreateWith(string id, string name)
    {
        var fileName = PrepareFileWith(
            $"{id}, {name}, 23-B|47-H",
            "64, mary, 55-B|31-H|67-A"
        );

        return new FlatFileAccountRepository(fileName);
    }

    protected override IAccountRepository CreateWithout(string id, string name)
    {
        var fileName = PrepareFileWith(
            $"NOT-{id}, NOT-{name}, 23-B|47-H",
            "64, mary, 55-B|31-H|67-A"
        );

        return new FlatFileAccountRepository(fileName);
    }

    [Fact]
    public void MissingFile()
    {
        PrepareFileWith(
            "23, john, 23-B|47-H",
            "64, mary, 55-B|31-H|67-A"
        );
        var fileName = RandomName();

        var repo = new FlatFileAccountRepository(fileName);

        Assert.Null(repo.Load("23"));
    }

    private static string RandomName() => 
        Guid.NewGuid().ToString();

    private static string PrepareFileWith(params string[] lines)
    {
        const string fileName = "./accounts.txt";
        File.WriteAllLines(fileName, lines ?? Array.Empty<string>());
        return fileName;
    }
}
