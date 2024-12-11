﻿using AccessControl.App;
using Moq;
using Xunit;

namespace AccessControl.Tests;

public class AccessControlServiceTests
{
    /*
     * TEST LIST:
     * [X] account allowed
     * [X] account denied
     * [X] unknown account
     */

    [Fact]
    public void AccountAllowed()
    {
        accountRepository
            .Setup(x => x.Load("23"))
            .Returns(new Account("23", "john", new[] { "42-B" }));

        var accessControl = new AccessControlService(
            accountRepository.Object,
            display.Object);

        accessControl.Check("23", "42-B");

        display.Verify(x => x.ShowWelcomeMessage("john"));
    }

    [Fact]
    public void AccountDenied()
    {
        accountRepository
            .Setup(x => x.Load("23"))
            .Returns(new Account("23", "john", new[] { "42-B" }));

        var accessControl = new AccessControlService(
            accountRepository.Object,
            display.Object);

        accessControl.Check("23", "NOT-MY-GATE");

        display.Verify(x => x.ShowUnauthorizedAccess("john"));
    }

    [Fact]
    public void UnknownAccount()
    {
        accountRepository
            .Setup(x => x.Load(It.IsAny<string>()))
            .Throws<UnknownAccountException>();

        var accessControl = new AccessControlService(
            accountRepository.Object,
            display.Object);

        accessControl.Check("DOES-NOT-EXIST", "42-B");

        display.Verify(x => x.ShowUnknownAccount());
    }

    private readonly Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
    private readonly Mock<IDisplay> display = new Mock<IDisplay>();
}
