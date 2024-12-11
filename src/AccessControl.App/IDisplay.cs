namespace AccessControl.App;

public interface IDisplay
{
    void ShowWelcomeMessage(string name);
    void ShowUnauthorizedAccess(string name);
    void ShowUnknownAccount();
}
