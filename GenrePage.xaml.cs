using anime.Model;
namespace anime;

public partial class GenrePage : ContentPage
{
    Anime an;
    public GenrePage(Anime anime)
    {
        InitializeComponent();
        an = anime;
    }


    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var genre = (Genre)BindingContext;
        await App.Database.SaveGenreAsync(genre);
        listView.ItemsSource = await App.Database.GetGenreAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var genre = (Genre)BindingContext;
        await App.Database.DeleteGenreAsync(genre);
        listView.ItemsSource = await App.Database.GetGenreAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetGenreAsync();
    }


    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Genre p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Genre;
            var lp = new ListGenre()
            {
                AnimeId = an.Id,
                GenreId = p.Id
            };
            await App.Database.SaveListGenreAsync(lp);
            p.ListGenres = new List<ListGenre> { lp };
            await Navigation.PopAsync();
        }

    }
}