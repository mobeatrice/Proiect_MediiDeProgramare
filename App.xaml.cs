using anime.Data;

namespace anime
{
    public partial class App : Application
    {

        static AnimeDbContext database;
        public static AnimeDbContext Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   AnimeDbContext(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "Anime.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
