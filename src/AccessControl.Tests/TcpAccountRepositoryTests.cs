using AccessControl.App;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AccessControl.Tests
{
    public class TcpAccountRepositoryTests : AccountRepositoryContractTests
    {
        protected override IAccountRepository CreateWith(String id, String name)
        {
            var (address, port) = PrepareTcpServer(
                $"{id}, {name}, 23-B|47-H",
                "64, mary, 55-B|31-H|67-A"
            );

            return new TcpAccountRepository(address, port);
        }

        protected override IAccountRepository CreateWithout(String id, String name)
        {
            var (address, port) = PrepareTcpServer(
                $"NOT-{id}, NOT-{name}, 23-B|47-H",
                "64, mary, 55-B|31-H|67-A"
            );

            return new TcpAccountRepository(address, port);
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