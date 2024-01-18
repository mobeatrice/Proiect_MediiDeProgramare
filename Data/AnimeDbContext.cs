using anime.Model;
using SQLite;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anime.Data
{ 
    public class AnimeDbContext
    {
        public SQLiteConnection Database { get; private set; }

        public AnimeDbContext(string dbPath)
    {
            Database = new SQLiteConnection(dbPath);
            Database.CreateTable<Anime>();
            Database.CreateTable<Genre>();
            Database.CreateTable<Character>();
            Database.CreateTable<AnimeCharacter>();
    }

        
        public TableQuery<Anime> AnimesTable => Database.Table<Anime>();
        public TableQuery<Genre> GenresTable => Database.Table<Genre>();
        public TableQuery<Character> CharactersTable => Database.Table<Character>();
        public TableQuery<AnimeCharacter> AnimeCharactersTable => Database.Table<AnimeCharacter>();


    }
}
