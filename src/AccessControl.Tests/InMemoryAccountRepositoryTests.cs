using System;
using AccessControl.App;

namespace AccessControl.Tests
{
    public class InMemoryAccountRepositoryTests : AccountRepositoryContractTests
    {
        protected override IAccountRepository CreateWith(String id, String name)
        {
            return new InMemoryAccountRepository(
                new Account(id, name, new String[0]),
                new Account("64", "mary", new String[0])
                );
        }

        protected override IAccountRepository CreateWithout(String id, String name)
        {
            return new InMemoryAccountRepository(
                new Account($"NOT-{id}", $"NOT-{name}", new String[0]),
                new Account("64", "mary", new String[0])
                );
        }
    }
}