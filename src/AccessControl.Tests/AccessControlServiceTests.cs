using System;
using AccessControl.App;
using Moq;
using Xunit;

namespace AccessControl.Tests
{
    public class AccessControlServiceTests
    {
        [Fact]
        public void AccountAllowed()
        {
            var accountRepository = new InMemoryAccountRepository(new Account("23", "john", new[] { "42-B" }));
            var display = new Mock<IDisplay>();

            var accessControl = new AccessControlService(
                                        accountRepository,
                                        display.Object);

            accessControl.Check("23", "42-B");

            display.Verify(x => x.ShowWelcomeMessage("john"));
        }

        [Fact]
        public void AccountDenied()
        {
            var accountRepository = new InMemoryAccountRepository(new Account("23", "john", new[] { "42-B" }));
            var display = new Mock<IDisplay>();

            var accessControl = new AccessControlService(
                                        accountRepository,
                                        display.Object);

            accessControl.Check("23", "NOT-MY-GATE");

            display.Verify(x => x.ShowUnauthorizedAccess("john"));
        }

        [Fact]
        public void UnknownAccount()
        {
            var accountRepository = new InMemoryAccountRepository(new Account("23", "john", new[] { "42-B" }));
            var display = new Mock<IDisplay>();

            var accessControl = new AccessControlService(
                                        accountRepository,
                                        display.Object);

            accessControl.Check("DOES-NOT-EXIST", "42-B");

            display.Verify(x => x.ShowUnknownAccount());
        }
    }
}