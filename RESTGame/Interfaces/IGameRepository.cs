using RESTGame.Models;

namespace RESTGame.Interfaces
{
    public interface IGameRepository
    {
        Game AddGame(Game game);
        Game? UpdateGame(int id, Game data);
        Game? DeleteGameById(int id);
        Game? GetGameById(int id);
        IEnumerable<Game> GetGames(int? minReleaseYear = null, string? name = null, string? genre = null, string? sortOrder = null);

    }
}
