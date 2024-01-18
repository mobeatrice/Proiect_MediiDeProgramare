using anime.Model;

namespace anime;

public partial class MyLists : ContentPage
{
    public MyLists()
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
        await Navigation.PushAsync(new List
        {
            BindingContext = new Anime()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new List
            {
                BindingContext = e.SelectedItem as Anime
            });
        }
    }
}
