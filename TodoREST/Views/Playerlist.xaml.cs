using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TodoREST.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoREST.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Playerlist : ContentPage
    {
        private Entry _nameEntry;
        private Button _saveButton;
        private int antalspillere;
        private int i;

        private string _dbPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "myDB.db3");

        public Playerlist(int antal)
        {
            this.Title = "Spillerliste";

            StackLayout stackLayout = new StackLayout();

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "Playername";
            stackLayout.Children.Add(_nameEntry);

            _saveButton = new Button();
            _saveButton.Text = "Klar";
            _saveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;

            antalspillere = antal;
        }

        //gem spillere ind i db
        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            while (antalspillere>i)
            {
                var db = new SQLiteConnection(_dbPath);
                db.CreateTable<Players>();

                var maxPK = db.Table<Players>().OrderByDescending(c => c.Id).FirstOrDefault();

                Players players = new Players()
                {
                    Id = (maxPK == null ? 1 : maxPK.Id + 1),
                    Name = _nameEntry.Text

                };
                db.Insert(players);
                
                await DisplayAlert(null, players + "Gemt", "Ok");
                i++;
                break;
            }

            if (antalspillere<=i)
            {
                await Navigation.PushAsync(new SeSpillere());
            }
            
            //Tilføj navigation til næste side

        }
    }
}