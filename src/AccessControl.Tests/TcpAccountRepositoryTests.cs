using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AccessControl.App;
using Xunit;

namespace AccessControl.Tests;

public class TcpAccountRepositoryTests
{
    /*
     * TEST LIST:
     * [X] account found
     * [X] account not found
     */

    [Fact]
    public void Found()
    {
        var (address, port) = PrepareTcpServer(
            "23, john, 23-B|47-H",
            "64, mary, 55-B|31-H|67-A"
        );

        var repo = new TcpAccountRepository(address, port);

        var account = repo.Load("23");

        Assert.Equal("john", account.Name);
    }

    [Fact]
    public void NotFound()
    {
        var (address, port) = PrepareTcpServer(
            "23, john, 23-B|47-H",
            "64, mary, 55-B|31-H|67-A"
        );

        var repo = new TcpAccountRepository(address, port);

        Assert.Null(repo.Load("NOT-23"));
    }

    private static (string, int) PrepareTcpServer(params string[] lines)
    {
        const int port = 13000;
        Task.Run(() =>
        {
            var server = new TcpListener(IPAddress.Any, port);
            server.Start();

            using var client = server.AcceptTcpClient();
            using var stream = client.GetStream();
            
            var dataIn = new byte[1024];
            var bytes = stream.Read(dataIn, 0, dataIn.Length);
            var id = Encoding.ASCII.GetString(dataIn, 0, bytes);
            
            var line = lines.FirstOrDefault(x => x.StartsWith(id));
            
            var dataOut = Encoding.ASCII.GetBytes(line ?? string.Empty);
            stream.Write(dataOut, 0, dataOut.Length);
            client.Close();

            server.Stop();
        });
        return ("localhost", port);
    }
}
