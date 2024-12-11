using System.Linq;

namespace AccessControl.App;

public class Account
{
    public string Id { get; }
    public string Name { get; }
    private readonly string[] allowedGates;

    public Account(string id, string name, string[] allowedGates)
    {
        Id = id;
        Name = name;
        this.allowedGates = allowedGates;
    }

    public bool CanAccess(string gateId) => 
        allowedGates.Contains(gateId);
}
