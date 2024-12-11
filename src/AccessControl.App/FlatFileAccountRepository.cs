using System.IO;
using System.Linq;

namespace AccessControl.App;

public class FlatFileAccountRepository : IAccountRepository
{
    private readonly string fileName;

    public FlatFileAccountRepository(string fileName) =>
        this.fileName = fileName;

    public Account Load(string id)
    {
        if (!File.Exists(fileName))
            return null;

        return File.ReadAllLines(fileName)
            .Select(Parse)
            .FirstOrDefault(x => x.Id == id);
    }

    private static Account Parse(string line)
    {
        var parts = line.Split(",").Select(x => x.Trim()).ToArray();
        return new Account(parts[0], parts[1], parts[2].Split("|"));
    }
}
