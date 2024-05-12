namespace Socks5.Core.RelayPlugin;

public class RelayConfigs
{
    private static List<RelayServer> Servers = new();
    public static int index = -1;
    static Random rnd = new Random();

    public static void addRelayServer(string ipOrDomain, int port, string username, string password)
    {
        RelayServer server = new RelayServer(ipOrDomain, port, username, password);
        Servers.Add(server);
    }

    public static RelayServer getRelayServer()
    {
        if (index < 0 || index >= Servers.Count)
        {
            int r = rnd.Next(Servers.Count);
            return Servers[r];
        }
        return Servers[index];
    }

    public static bool RelayEnabled()
    {
        return Servers.Count > 0;
    } 
}