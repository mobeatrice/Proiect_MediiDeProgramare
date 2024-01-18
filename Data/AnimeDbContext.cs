using anime.Model;
using SQLite;


namespace anime.Data
{
    public class AnimeDbContext
    {
        readonly SQLiteAsyncConnection _database;

        public AnimeDbContext(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Anime>().Wait();

            _database.CreateTableAsync<Genre>().Wait();
            _database.CreateTableAsync<ListGenre>().Wait();
            _database.CreateTableAsync<Character>().Wait();
            _database.CreateTableAsync<ListCharacter>().Wait();
        }


        //Character
        public Task<int> SaveCharacterAsync(Character character)
        {
            if (character.Id != 0)
            {
                return _database.UpdateAsync(character);
            }
            else
            {
                return _database.InsertAsync(character);
            }
        }
        public Task<int> DeleteCharacterAsync(Character character)
        {
            return _database.DeleteAsync(character);
        }
        public Task<List<Character>> GetCharacterAsync()
        {
            return _database.Table<Character>().ToListAsync();
        }

        //Genre
        public Task<int> SaveGenreAsync(Genre genre)
        {
            if (genre.Id != 0)
            {
                return _database.UpdateAsync(genre);
            }
            else
            {
                return _database.InsertAsync(genre);
            }
        }
        public Task<int> DeleteGenreAsync(Genre genre)
        {
            return _database.DeleteAsync(genre);
        }
        public Task<List<Genre>> GetGenreAsync()
        {
            return _database.Table<Genre>().ToListAsync();
        }

        //Anime
        public Task<List<Anime>> GetAnimeAsync()
        {
            return _database.Table<Anime>().ToListAsync();
        }
        public Task<Anime> GetAnimeAsync(int id)
        {
            return _database.Table<Anime>()
            .Where(i => i.Id == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveAnimeAsync(Anime anime)
        {
            if (anime.Id != 0)
            {
                return _database.UpdateAsync(anime);
            }
            else
            {
                return _database.InsertAsync(anime);
            }
        }
        public Task<int> DeleteAnimeAsync(Anime slist)
        {
            return _database.DeleteAsync(slist);
        }

        public Task<int> SaveListGenreAsync(ListGenre listp)
        {
            if (listp.Id != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Genre>> GetListGenreAsync(int shoplistid)
        {
            return _database.QueryAsync<Genre>(
            "select P.Id, P.Name from Genre P"
            + " inner join ListGenre LP"
            + " on P.Id = LP.GenreId where LP.AnimeId = ?",
            shoplistid);
        }


        public Task<int> SaveListCharacterAsync(ListCharacter listp)
        {
            if (listp.Id != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Character>> GetListCharacterAsync(int shoplistid)
        {
            return _database.QueryAsync<Character>(
            "select P.Id, P.Name from Character P"
            + " inner join ListCharacter LP"
            + " on P.Id = LP.CharacterId where LP.AnimeId = ?",
            shoplistid);
        }
    }
}


