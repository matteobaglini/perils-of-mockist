using System;
using System.Linq;

namespace AccessControl.App;

public class Account
{
    public string Id { get; }
    public string Name { get; }
    private readonly string[] permittedGates;

    public Account(string id, string name, string[] permittedGates)
    {
        Id = id;
        Name = name;
        this.permittedGates = permittedGates;
    }

    public Boolean CanAccess(string gateId)
    {
        return permittedGates.Contains(gateId);
    }
}
