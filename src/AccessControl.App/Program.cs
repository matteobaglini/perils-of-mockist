using System;

namespace AccessControl.App;

class Program
{
    static void Main(string[] args)
    {
        var repository = new FlatFileAccountRepository("accounts.txt");
        var display = new ConsoleDisplay(Console.Out);
        var service = new AccessControlService(repository, display);

        // service.Check("23", "23-B"); // Welcome John!
        // service.Check("23", "67-A"); // Access denied John!
        // service.Check("some-account-id", "some-gate-id"); // Sorry, we don't know you.
    }
}
