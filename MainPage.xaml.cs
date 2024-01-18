namespace anime
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void ViewAnimeList_Clicked(object sender, EventArgs e)
        {
            // Create an instance of the AnimeListPage and navigate to it
            var animeListPage = new AnimeListPage();
            await Navigation.PushAsync(animeListPage);
        }
    }

}
