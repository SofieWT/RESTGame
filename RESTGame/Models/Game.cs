namespace RESTGame.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ReleaseYear { get; set; }
        public string? Genre { get; set; }

        public Game()
        {
            
        }
        public Game(string name, int year, string genre)
        {
            Name = name;
            ReleaseYear = year;
            Genre = genre;
        }
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Releaseyear: {ReleaseYear}, Genre: {Genre}";
        }

    }
}
