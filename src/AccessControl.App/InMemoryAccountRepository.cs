using System;
using System.Linq;

namespace AccessControl.App
{
    public class InMemoryAccountRepository : IAccountRepository
    {
        private readonly Account[] accounts;

        public InMemoryAccountRepository(params Account[] accounts)
        {
            this.accounts = accounts ?? new Account[0];
        }

        public Account Load(String id)
        {
            return accounts.FirstOrDefault(x => x.Id == id);
        }
    }
}