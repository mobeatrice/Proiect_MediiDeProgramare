using SQLite;
using SQLiteNetExtensions.Attributes;

namespace anime.Model
{
    public class ListGenre
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(Anime))]
        public int AnimeId { get; set; }
        public int GenreId { get; set; }
    }
}
