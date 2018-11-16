using System;
using System.Linq;

namespace AccessControl.App
{
    public class Account
    {
        public String Id { get; }
        public String Name { get; }
        private readonly String[] permittedGates;

        public Account(String id, String name, String[] permittedGates)
        {
            Id = id;
            Name = name;
            this.permittedGates = permittedGates;
        }

        public Boolean CanAccess(String gateId)
        {
            return permittedGates.Contains(gateId);
        }
    }
}