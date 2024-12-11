namespace AccessControl.App;

public class AccessControlService
{
    private readonly IAccountRepository accountRepository;
    private readonly IDisplay display;

    public AccessControlService(IAccountRepository accountRepository, IDisplay display)
    {
        this.accountRepository = accountRepository;
        this.display = display;
    }

    public void Check(string accountId, string gateId)
    {
        try
        {
            var account = accountRepository.Load(accountId);
            if (account.CanAccess(gateId))
                display.ShowWelcomeMessage(account.Name);
            else
                display.ShowUnauthorizedAccess(account.Name);
        }
        catch (UnknownAccountException)
        {
            display.ShowUnknownAccount();
        }
    }
}
