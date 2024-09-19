namespace Model;

public class GameServerListService
{
    private readonly Dictionary<Guid, GameServerListing> _gameServerListingById = [];
    private readonly SortedSet<GameServerListing> _gameServerListings = new(new RefreshComparer());

    // Todo: Use DTO instead of record
    public void RegisterGameServer(GameServerListing gameServerListing)
    {
        _gameServerListings.Add(gameServerListing);
        _gameServerListingById[gameServerListing.Id] = gameServerListing;
    }

    public void RefreshGameServer(Guid id)
    {
        if (!_gameServerListingById.TryGetValue(id, out GameServerListing? gameServerListing))
            return;

        gameServerListing.LastRefresh = DateTime.UtcNow;
        _gameServerListings.Remove(gameServerListing);
        _gameServerListings.Add(gameServerListing);
    }

    public bool UnregisterGameServer(Guid id) => _gameServerListingById.Remove(id, out GameServerListing? gameServerListing) && _gameServerListings.Remove(gameServerListing);

    public IEnumerable<GameServerListing> GetGameServerListings() => _gameServerListingById.Values;
}

internal class RefreshComparer : IComparer<GameServerListing>
{
    public int Compare(GameServerListing? x, GameServerListing? y)
        => !ReferenceEquals(x, y) ? y is null ? 1 : x is null ? -1 : x.LastRefresh.CompareTo(y.LastRefresh) : 0;
}