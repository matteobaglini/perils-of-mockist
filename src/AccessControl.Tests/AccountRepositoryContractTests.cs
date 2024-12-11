using AccessControl.App;
using Xunit;

namespace AccessControl.Tests;

public abstract class AccountRepositoryContractTests
{
    protected abstract IAccountRepository CreateWith(string id, string name);

    [Fact]
    public void Found()
    {
        var repo = CreateWith("23", "john");

        var account = repo.Load("23");

        Assert.Equal("john", account.Name);
    }

    protected abstract IAccountRepository CreateWithout(string id, string name);

    [Fact]
    public void NotFound()
    {
        var repo = CreateWithout("23", "john");

        Assert.Null(repo.Load("23"));
    }
}
