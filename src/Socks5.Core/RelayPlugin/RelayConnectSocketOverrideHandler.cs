using System.Net;
using Socks5.Core.Plugin;
using Socks5.Core.Socks;
using Socks5.Core.TCP;

namespace Socks5.Core.RelayPlugin;

internal class RelayConnectSocketOverrideHandler : ConnectSocketOverrideHandler
{
    public override bool Enabled
    {
        get { return RelayConfigs.RelayEnabled(); }
        set { }
    }

    public override bool OnStart()
    {
        return true;
    }

    public override Client OnConnectOverride(SocksRequest sr)
    {
        var rs = RelayConfigs.getRelayServer();
        var relayClient = new Socks5Client.Socks5Client(rs.IpOrDomain, rs.Port, 
            sr.Address, sr.Port, rs.Username, rs.Password);
        if (relayClient.Connect())
        {
            return relayClient.Client!;
        }
        else
        {
            relayClient.Client?.Disconnect();
            throw new Exception("Socks5 server could not be reached.");
        }
    }
}