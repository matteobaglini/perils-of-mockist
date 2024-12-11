using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace AccessControl.App;

public class TcpAccountRepository : IAccountRepository
{
    private readonly string address;
    private readonly int port;

    public TcpAccountRepository(string address, int port)
    {
        this.address = address;
        this.port = port;
    }

    public Account Load(string id)
    {
        using var client = new TcpClient(address, port);
        using var stream = client.GetStream();
        
        var dataOut = Encoding.ASCII.GetBytes(id);
        stream.Write(dataOut, 0, dataOut.Length);

        var dataIn = new byte[1024];
        var bytes = stream.Read(dataIn, 0, dataIn.Length);
        var responseData = Encoding.ASCII.GetString(dataIn, 0, bytes);

        return string.IsNullOrWhiteSpace(responseData)
            ? null
            : Parse(responseData);
    }

    private static Account Parse(string line)
    {
        var parts = line.Split(",").Select(x => x.Trim()).ToArray();
        return new Account(parts[0], parts[1], parts[2].Split("|"));
    }
}
