using System;
using System.IO;
using AccessControl.App;
using Xunit;

namespace AccessControl.Tests
{
    public class ConsoleDisplayTests
    {
       /*
        * TEST LIST:
        * X welcome message
        * - unauth message
        * - unknown message
        */

        [Fact]
        public void WelcomeMessage()
        {
            var writer = new StringWriter();
            var display = new ConsoleDisplay(writer);

            display.ShowWelcomeMessage("john");

            Assert.Equal("Welcome john!" + Environment.NewLine, writer.ToString());
        }
    }
}