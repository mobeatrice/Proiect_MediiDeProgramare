using anime.Model;
namespace anime;

public partial class CharacterPage : ContentPage
{
    Anime anc;
	public CharacterPage(Anime animec)
	{
		InitializeComponent();
        anc = animec;
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var character = (Character)BindingContext;
        await App.Database.SaveCharacterAsync(character);
        CharacterlistView.ItemsSource = await App.Database.GetCharacterAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var character = (Character)BindingContext;
        await App.Database.DeleteCharacterAsync(character);
        CharacterlistView.ItemsSource = await App.Database.GetCharacterAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        CharacterlistView.ItemsSource = await App.Database.GetCharacterAsync();
    }


    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Character p;
        if (CharacterlistView.SelectedItem != null)
        {
            p = CharacterlistView.SelectedItem as Character;
            var lp = new ListCharacter()
            {
                AnimeId = anc.Id,
                CharacterId = p.Id
            };
            await App.Database.SaveListCharacterAsync(lp);
            p.ListCharacters = new List<ListCharacter> { lp };
            await Navigation.PopAsync();
        }

    }
}