﻿using System;
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
        * X unauth message
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

        [Fact]
        public void UnauthorizedMessage()
        {
            var writer = new StringWriter();
            var display = new ConsoleDisplay(writer);

            display.ShowUnauthorizedAccess("john");

            Assert.Equal("Access denied john!" + Environment.NewLine, writer.ToString());
        }
    }
}