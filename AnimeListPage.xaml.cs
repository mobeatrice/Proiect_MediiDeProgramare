using anime.Data;
using anime.Model;
using Microsoft.Maui.Controls;
namespace anime
{
    public partial class AnimeListPage : ContentPage
    {
        public AnimeListPage()
        {
            InitializeComponent();
        }

        

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            AnimeListView.ItemsSource = await App.Database.GetAnimeAsync();
        }
        async void OnAnimeAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddAnimePage
            {
                BindingContext = new Anime()
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AddAnimePage
                {
                    BindingContext = e.SelectedItem as Anime
                });
            }
        }



    }
}