﻿using System;
using System.IO;
using AccessControl.App;
using Xunit;

namespace AccessControl.Tests
{
    public class FlatFileAccountRepositoryTests : AccountRepositoryContractTests
    {
        protected override IAccountRepository CreateWith(String id, String name)
        {
            var fileName = PrepareFileWith(
                $"{id}, {name}, 23-B|47-H",
                "64, mary, 55-B|31-H|67-A"
            );

            return new FlatFileAccountRepository(fileName);
        }

        [Fact]
        public void NotFound()
        {
            var fileName = PrepareFileWith(
                "23, john, 23-B|47-H",
                "64, mary, 55-B|31-H|67-A"
            );

            var repo = new FlatFileAccountRepository(fileName);

            Assert.Throws<UnknownAccountException>(() => repo.Load("NOT-23"));
        }

        [Fact]
        public void MissingFile()
        {
            var fileName = RandomName();

            var repo = new FlatFileAccountRepository(fileName);

            Assert.Null(repo.Load("23"));
        }

        private static String RandomName()
        {
            return Guid.NewGuid().ToString();
        }

        private static String PrepareFileWith(params String[] lines)
        {
            var fileName = "./accounts.txt";
            File.WriteAllLines(fileName, lines ?? new String[0]);
            return fileName;
        }
    }
}