using RESTGame.Interfaces;
using RESTGame.Models;

namespace RESTGame.Services
{
    public class GameRepositoryList : IGameRepository
    {
        private List<Game> _games = new List<Game>();
        private int _nextId = 1;

        public Game AddGame(Game game)
        {
            game.Id = _nextId++;
            _games.Add(game);
            return game;
        }

        public Game? DeleteGameById(int id)
        {
            Game gameToDelete = GetGameById(id);
            if (gameToDelete == null)
            {
                return null;
            }
            _games.Remove(gameToDelete);
            return gameToDelete;
        }

        public Game? GetGameById(int id)
        {
            return _games.FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<Game> GetGames(int? minReleaseYear = null, string? name = null, string? genre = null, string? sortOrder = null)
        {
            IEnumerable<Game> result = _games.AsReadOnly();
            if (minReleaseYear != null)
            {
                result = result.Where(g => g.ReleaseYear >= minReleaseYear);
            }
            if(name != null)
            {
                result = result.Where(g => g.Name != null && g.Name.Contains(name));
            }
            if ((genre!=null))
            {
                result = result.Where(g => g.Genre != null && g.Genre == genre);
            }
            if (sortOrder != null)
            {
                switch (sortOrder.ToLower())
                {
                    case "name":
                    case "name_asc":
                        result = result.OrderBy(g => g.Name);
                        break;
                    case "release_year":
                    case "release_year_asc":
                        result = result.OrderBy(g => g.ReleaseYear);
                        break;
                    case "genre":
                    case "genre_asc":
                        result = result.OrderBy(g => g.Genre);
                        break;
                    default:
                        break;
                }
            }
             return result;
        }

        public Game? UpdateGame(int id, Game data)
        {


            Game gameToUpdate = GetGameById(id);
            if (gameToUpdate != null)
            {
                gameToUpdate.Name = data.Name;
                gameToUpdate.ReleaseYear = data.ReleaseYear;
                gameToUpdate.Genre = data.Genre;
            }
            return gameToUpdate;
        }
    }
}
