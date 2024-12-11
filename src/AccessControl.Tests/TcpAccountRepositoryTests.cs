using AccessControl.App;
using Xunit;

namespace AccessControl.Tests;

public class TcpAccountRepositoryTests
{
    /*
     * TEST LIST:
     * [X] account found
     * [X] account not found
     */

    [Fact]
    public void Found()
    {
        var (address, port) = new AccountsTcpServer(
            "23, john, 23-B|47-H",
            "64, mary, 55-B|31-H|67-A"
        ).Start();

        var repo = new TcpAccountRepository(address, port);

        var account = repo.Load("23");

        Assert.Equal("john", account.Name);
    }

    [Fact]
    public void NotFound()
    {
        var (address, port) = new AccountsTcpServer(
            "23, john, 23-B|47-H",
            "64, mary, 55-B|31-H|67-A"
        ).Start();

        var repo = new TcpAccountRepository(address, port);

        Assert.Null(repo.Load("NOT-23"));
    }
}
