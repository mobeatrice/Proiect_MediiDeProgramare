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

    private void DeleteAnime_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is AnimeDetailViewModel viewModel)
        {
            
            int animeId = GetAnimeIdFromViewModel(viewModel);
            bool isDeleted = DeleteAnimeFromDatabase(animeId);

            if (isDeleted)
            {
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Error", "Failed to delete anime.", "OK");
            }
        }
    }

    private int GetAnimeIdFromViewModel(AnimeDetailViewModel viewModel)
    {
        
        return 1; 
    }

    
    private bool DeleteAnimeFromDatabase(int animeId)
    {
        try
        {
          
             var animeToRemove = _dbContext.AnimesTable.FirstOrDefault(a => a.Id == animeId);
             if (animeToRemove != null)
             {
                _dbContext.Database.Delete(animeToRemove);
                return true;
            }

            return false; 
        }
        catch (Exception ex)
        {
            
            return false; 
        }
    }
}

