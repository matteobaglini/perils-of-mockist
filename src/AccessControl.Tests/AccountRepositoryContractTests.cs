using System;
using AccessControl.App;
using Xunit;

namespace AccessControl.Tests
{
    public abstract class AccountRepositoryContractTests
    {
        protected abstract IAccountRepository CreateWith(String id, String name);

        [Fact]
        public void Found()
        {
            var repo = CreateWith("23", "john");

            var account = repo.Load("23");

            Assert.Equal("john", account.Name);
        }
    }
}