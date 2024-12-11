using System;
using System.Linq;

namespace AccessControl.App;

public class InMemoryAccountRepository : IAccountRepository
{
    private readonly Account[] accounts;

    public InMemoryAccountRepository(params Account[] accounts) =>
        this.accounts = accounts ?? Array.Empty<Account>();

    public Account Load(string id) =>
        accounts.FirstOrDefault(x => x.Id == id);
}
