﻿using System;
using System.IO;
using System.Linq;

namespace AccessControl.App
{
    public class FlatFileAccountRepository : IAccountRepository
    {
        private readonly String fileName;

        public FlatFileAccountRepository(String fileName)
        {
            this.fileName = fileName;
        }

        public Account Load(String id)
        {
            var all = File.ReadAllLines(fileName);
            var accounts = all.Select(Parse).ToList();
            var accountFound = accounts.FirstOrDefault(x => x.Id == id);
            if (accountFound == null)
                throw new UnknownAccountException();

            return accountFound;
        }
        
        private static Account Parse(string line)
        {
            var parts = line.Split(",").Select(x => x.Trim()).ToArray();
            return new Account(parts[0], parts[1], parts[2].Split("|"));
        }
    }
}