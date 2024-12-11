using System;

namespace AccessControl.App;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        
        // service.Check("23", "23-B"); // Welcome John!
        // service.Check("23", "67-A"); // Access denied John!
        // service.Check("some-account-id", "some-gate-id"); // Sorry, we don't know you.
    }
}
