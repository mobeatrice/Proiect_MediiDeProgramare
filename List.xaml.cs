using anime.Model;

namespace anime;

public partial class List : ContentPage
{
	public List()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Anime)BindingContext;
        await App.Database.SaveAnimeAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Anime)BindingContext;
        await App.Database.DeleteAnimeAsync(slist);
        await Navigation.PopAsync();
    }


    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GenrePage((Anime)
       this.BindingContext)
        {
            BindingContext = new Genre()
        });

    }
    async void OnChooseButtonClickedCharacter(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CharacterPage((Anime)
       this.BindingContext)
        {
            BindingContext = new Character()
        });

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var ani = (Anime)BindingContext;

        listView.ItemsSource = await App.Database.GetListGenreAsync(ani.Id);
        CharacterlistView.ItemsSource = await App.Database.GetListCharacterAsync(ani.Id);
    }


}