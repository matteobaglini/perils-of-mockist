using System;
using System.IO;

namespace AccessControl.App;

class Program
{
    static void Main(string[] args)
    {
        var fileName = "accounts.txt";
        Touch(fileName);

        var repository = new FlatFileAccountRepository(fileName);
        var display = new ConsoleDisplay(Console.Out);
        var service = new AccessControlService(repository, display);

        service.Check("some-account-id", "some-gate-id");
    }

    private static void Touch(string fileName)
    {
        using var text = File.CreateText(fileName);
    }
}
