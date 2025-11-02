using System.Net.Sockets;
using System.Text;

namespace Inventory_system.Models;

public class Robot
{
    public const int UrsPort = 30002;
    public const int DashPort = 29999;
    public string IpAddress = "localhost";

    protected void SendString(int port, string message)
    {
        using var client = new TcpClient(IpAddress, port);
        using var stream = client.GetStream();
        var bytes = Encoding.ASCII.GetBytes(message);
        stream.Write(bytes, 0, bytes.Length);
    }

    protected void SendUrscript(string urscript)
    {
        SendString(DashPort, "brake release\n");
        SendString(UrsPort, urscript);
    }
}