using System.Net;

namespace Model;

public record GameServerListing
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; init; } = "Unknown Game Server";
    public IPEndPoint[] ListeningAddresses { get; init; } = [];
    public bool IsOnline { get; init; }
    public DateTime LastRefresh { get; set; } = DateTime.MaxValue;
}