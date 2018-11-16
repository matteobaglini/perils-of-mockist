using System;
using AccessControl.App;

namespace AccessControl.Tests
{
    public class InMemoryAccountRepositoryTests : AccountRepositoryContractTests
    {
        protected override IAccountRepository CreateWith(String id, String name)
        {
            throw new NotImplementedException();
        }

        protected override IAccountRepository CreateWithout(String id, String name)
        {
            throw new NotImplementedException();
        }
    }
}