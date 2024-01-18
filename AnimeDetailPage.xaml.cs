using anime.Data;
using anime.Model;

namespace anime;

public partial class AnimeDetailPage : ContentPage
{
    private AnimeDbContext _dbContext;
    public AnimeDetailPage()
	{
		InitializeComponent();
        _dbContext = new AnimeDbContext(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "anime.db"));
       
    }

   
}

