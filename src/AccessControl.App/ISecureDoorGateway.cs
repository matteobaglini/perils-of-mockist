using System;

namespace AccessControl.App
{
    public interface IDisplay
    {
        void ShowWelcomeMessage(String name);
        void ShowUnauthorizedAccess(String name);
        void ShowUnknownAccount();
    }
}