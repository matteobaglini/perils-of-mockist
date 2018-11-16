using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var (address, port) = PrepareTcpServer(
                "23, john, 23-B|47-H",
                "64, mary, 55-B|31-H|67-A"
            );

            var repository = new TcpAccountRepository(address, port);
            var display = new ConsoleDisplay(Console.Out);
            var service = new AccessControlService(repository, display);

            service.Check("some-account-id", "some-gate-id");
        }

        private static (String, Int32) PrepareTcpServer(params String[] lines)
        {
            var address = "127.0.0.1";
            var port = 13000;
            Task.Run(() =>
            {
                var server = new TcpListener(IPAddress.Parse(address), port);
                server.Start();

                using (var client = server.AcceptTcpClient())
                using (var stream = client.GetStream())
                {
                    var dataIn = new Byte[1024];

                    var bytes = stream.Read(dataIn, 0, dataIn.Length);
                    var id = Encoding.ASCII.GetString(dataIn, 0, bytes);
                    var line = lines.FirstOrDefault(x => x.StartsWith(id));
                    var dataOut = Encoding.ASCII.GetBytes(line ?? String.Empty);
                    stream.Write(dataOut, 0, dataOut.Length);

                    client.Close();
                }
                server.Stop();
            });
            return (address, port);
        }
    }
}
