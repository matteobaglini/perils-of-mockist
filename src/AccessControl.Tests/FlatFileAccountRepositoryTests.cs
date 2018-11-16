using System;
using System.IO;
using AccessControl.App;
using Xunit;

namespace AccessControl.Tests
{
    public class FlatFileAccountRepositoryTests
    {
        /*
         * TEST LIST:
         * X account found
         * - account not found
         * - missing file
         */

        [Fact]
        public void Found()
        {
            var fileName = PrepareFileWith(
                "23, john, 23-B|47-H",
                "64, mary, 55-B|31-H|67-A"
            );

            var repo = new FlatFileAccountRepository(fileName);

            var account = repo.Load("23");
            
            Assert.Equal("john", account.Name);
        }

        private static String PrepareFileWith(params String[] lines)
        {
            var fileName = "./accounts.txt";
            File.WriteAllLines(fileName, lines ?? new String[0]);
            return fileName;
        }

    }
}