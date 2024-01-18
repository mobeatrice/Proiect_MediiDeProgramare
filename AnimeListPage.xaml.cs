using anime.Data;
using anime.Model;
using Microsoft.Maui.Controls;
namespace anime
{
    public partial class AnimeListPage : ContentPage
    {
        private AnimeDbContext _dbContext;

        [Obsolete]
        public AnimeListPage()
        {
            InitializeComponent();
            _dbContext = new AnimeDbContext(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "anime.db"));
            RefreshAnimeList();
            NavigationPage.SetTitleView(this, new Label { Text = "Back", TextColor = Color.FromHex("#FF69B4") }); 
        }

        private void RefreshAnimeList()
        {
            var animeList = _dbContext.AnimesTable.ToList();
            AnimeListView.ItemsSource = animeList;
        }

        private async void AddAnime_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddAnimePage(_dbContext));
        }

        private async void AnimeListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Anime selectedAnime)
            {
                AnimeDetailViewModel viewModel = new AnimeDetailViewModel
                {
                    Title = selectedAnime.Title,
                };

                AnimeDetailPage animeDetailPage = new AnimeDetailPage
                {
                    BindingContext = viewModel
                };

                await Navigation.PushAsync(animeDetailPage);
            }
        }




    }
}