namespace AccessControl.App;

public interface IAccountRepository
{
    Account Load(string id);
}
