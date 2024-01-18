using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anime.Model
{
    using SQLite;

    [Table("Anime")] // This attribute maps the class to the "Anime" table in the database
    public class Anime
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int CharacterId { get; set; }
    }
}
