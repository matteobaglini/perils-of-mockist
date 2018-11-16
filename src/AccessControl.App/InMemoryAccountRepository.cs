using System;

namespace AccessControl.App
{
    public class InMemoryAccountRepository : IAccountRepository
    {
        public Account Load(String id)
        {
            throw new NotImplementedException();
        }
    }
}