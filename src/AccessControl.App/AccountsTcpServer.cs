using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AccessControl.App;

public class AccountsTcpServer
{
    private const int Port = 13000;

    private readonly string[] lines;

    public AccountsTcpServer(params string[] lines) =>
        this.lines = lines ?? Array.Empty<string>();

    public (string, int) Start()
    {
        Task.Run(() =>
        {
            var server = new TcpListener(IPAddress.Any, Port);
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
        Thread.Sleep(500);
        return ("localhost", Port);
    }
}
