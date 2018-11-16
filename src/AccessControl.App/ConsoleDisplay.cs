using System;
using System.IO;

namespace AccessControl.App
{
    public class ConsoleDisplay : IDisplay
    {
        private readonly TextWriter writer;

        public ConsoleDisplay(TextWriter writer)
        {
            this.writer = writer;
        }

        public void ShowWelcomeMessage(String name)
        {
            writer.WriteLine("Welcome {0}!", name);
        }

        public void ShowUnauthorizedAccess(String name)
        {
            writer.WriteLine("Access denied {0}!", name);
        }

        public void ShowUnknownAccount()
        {
            writer.WriteLine("Sorry, we don't know you.");
        }
    }
}