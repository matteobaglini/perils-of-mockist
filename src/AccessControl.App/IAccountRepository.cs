using System;

namespace AccessControl.App
{
    public interface IAccountRepository
    {
        Account Load(String id);
    }
}