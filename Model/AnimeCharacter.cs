using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anime.Model
{
    public class AnimeCharacter
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int AnimeId { get; set; }
        public int CharacterId { get; set; }
    }
}
