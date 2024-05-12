namespace Socks5.Core.RelayPlugin;

public class RelayServer
{
    public string IpOrDomain { get; }
    public int Port { get; }
    public string Username { get; }
    public string Password { get; }

    internal RelayServer(string ipOrDomain, int port, string username, string password)
    {
        IpOrDomain = ipOrDomain;
        Port = port;
        Username = username;
        Password = password;
    }

}