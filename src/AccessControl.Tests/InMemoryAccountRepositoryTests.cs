using AccessControl.App;

namespace AccessControl.Tests;

public class InMemoryAccountRepositoryTests : AccountRepositoryContractTests
{
    protected override IAccountRepository CreateWith(string id, string name)
    {
        return new InMemoryAccountRepository(
            new Account(id, name, new string[0]),
            new Account("64", "mary", new string[0])
        );
    }

    protected override IAccountRepository CreateWithout(string id, string name)
    {
        return new InMemoryAccountRepository(
            new Account($"NOT-{id}", $"NOT-{name}", new string[0]),
            new Account("64", "mary", new string[0])
        );
    }
}
