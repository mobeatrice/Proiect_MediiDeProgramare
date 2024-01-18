using SQLite;
using SQLiteNetExtensions.Attributes;

namespace anime.Model
{
    public class ListCharacter
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(Anime))]
        public int AnimeId { get; set; }
        public int CharacterId { get; set; }
    }
}
