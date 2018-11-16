using AccessControl.App;
using Moq;
using Xunit;

namespace AccessControl.Tests
{
    public class AccessControlServiceTests
    {
        /*
         * TEST LIST:
         * - account allowed
         * - account denied
         * - unknown account
         */

        [Fact]
        public void AccountAllowed()
        {
            var accountRepository = new Mock<IAccountRepository>();
            var display = new Mock<IDisplay>();

            accountRepository
                .Setup(x => x.Load("23"))
                .Returns(new Account("23", "john", new[] { "42-B" }));

            var accessControl = new AccessControlService(
                                        accountRepository.Object,
                                        display.Object);

            accessControl.Check("23", "42-B");

            display.Verify(x => x.ShowWelcomeMessage("john"));
        }

    }
}