using System;

namespace AccessControl.App;

class Program
{
    private static void Main(string[] args)
    {
        var (address, port) = new AccountsTcpServer(
            "23, John, 23-B|47-H",
            "64, Mary, 55-B|31-H|67-A"
        ).Start();

        var repository = new TcpAccountRepository(address, port);
        var display = new ConsoleDisplay(Console.Out);
        var service = new AccessControlService(repository, display);

        // service.Check("23", "23-B"); // Welcome John!
        // service.Check("23", "67-A"); // Access denied John!
        // service.Check("some-account-id", "some-gate-id"); // Sorry, we don't know you.
    }
}
