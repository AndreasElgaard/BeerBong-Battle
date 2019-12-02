using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoREST.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LokaltSpil : ContentPage
    {
        private Entry _players;
        private Button _confirm;
        //private string _players;
        public LokaltSpil()
        {
            this.Title = "Vælg spillere";

            StackLayout stackLayout = new StackLayout();
            var layoutOptions = LayoutOptions.Center;
            _players = new Entry();
            _players.Keyboard = Keyboard.Numeric;
            _players.Placeholder = "Antal spillere";
            stackLayout.Children.Add(_players);

            var layoutOptions2 = LayoutOptions.EndAndExpand;
            _confirm = new Button();
            _confirm.Text = "Bekræft";
            _confirm.Clicked += _confirm_Clicked;
            stackLayout.Children.Add(_confirm);

            Content = stackLayout;

        }

        private async void _confirm_Clicked(object sender, EventArgs e)
        {
            int antal = Convert.ToInt32(_players.Text);
            await Navigation.PushAsync(new Playerlist(antal));
        }

        //private async void Button_clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new Playerlist());
        //}



    }
}