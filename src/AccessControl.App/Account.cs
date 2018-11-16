using System;
using System.Linq;

namespace AccessControl.App
{
    public class Account
    {
        public String Name { get; }
        private readonly String id;
        private readonly String[] permittedGates;

        public Account(String id, String name, String[] permittedGates)
        {
            Name = name;
            this.id = id;
            this.permittedGates = permittedGates;
        }

        public Boolean CanAccess(String gateId)
        {
            return permittedGates.Contains(gateId);
        }
    }
}