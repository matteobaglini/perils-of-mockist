using System;

namespace AccessControl.App
{
    public interface IDisplay
    {
        void ShowWelcomeMessage(String name);
        void ShowUnauthroizedAccess(String name);
    }
}