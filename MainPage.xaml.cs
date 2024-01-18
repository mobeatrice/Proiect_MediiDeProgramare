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
           
            var animeListPage = new AnimeListPage();
            await Navigation.PushAsync(animeListPage);
        }
    }

}
