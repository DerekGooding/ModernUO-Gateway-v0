using System.Net;

namespace ModernUO_Gateway.Model;

public record GameServerListing
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; init; } = "Unknown Game Server";
    public IPEndPoint[] ListeningAddresses { get; init; } = Array.Empty<IPEndPoint>();
    public bool IsOnline { get; init; } = false;
    public DateTime LastRefresh { get; set; } = DateTime.MaxValue;
}