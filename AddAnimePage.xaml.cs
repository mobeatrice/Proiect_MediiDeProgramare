using System;
using anime.Data; // Import the correct namespace for AnimeDbContext
using anime.Model;
using Microsoft.Maui.Controls;

namespace anime
{
    public partial class AddAnimePage : ContentPage
    {
        private AnimeDbContext _dbContext;

        public AddAnimePage(AnimeDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
        }

        private async void AddAnime_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TitleEntry.Text) && !string.IsNullOrWhiteSpace(GenreEntry.Text) && !string.IsNullOrWhiteSpace(CharacterEntry.Text))
            {
              
                var newAnime = new Anime
                {
                    Title = TitleEntry.Text,
                    
                    GenreId = 1, 
                    CharacterId = 1
                };

               
                _dbContext.Database.Insert(newAnime);

                
                TitleEntry.Text = string.Empty;
                GenreEntry.Text = string.Empty;
                CharacterEntry.Text = string.Empty;
                await Navigation.PopToRootAsync();
            }
            else
            {
                DisplayAlert("Error", "Please fill in all fields.", "OK");
            }
        }


    }
}