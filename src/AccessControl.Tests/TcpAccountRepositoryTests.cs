using AccessControl.App;

namespace AccessControl.Tests;

public class TcpAccountRepositoryTests : AccountRepositoryContractTests
{
    protected override IAccountRepository CreateWith(string id, string name)
    {
        var (address, port) = new AccountsTcpServer(
            $"{id}, {name}, 23-B|47-H",
            "64, mary, 55-B|31-H|67-A"
        ).Start();

        return new TcpAccountRepository(address, port);
    }

    protected override IAccountRepository CreateWithout(string id, string name)
    {
        var (address, port) = new AccountsTcpServer(
            $"NOT-{id}, NOT-{name}, 23-B|47-H",
            "64, mary, 55-B|31-H|67-A"
        ).Start();

        return new TcpAccountRepository(address, port);
    }
}
