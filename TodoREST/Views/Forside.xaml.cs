using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoREST.Data;
using TodoREST.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoREST.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Forside : ContentPage
    { 

        bool isNewItem;
        public Forside(bool isNew = false)
        {

            InitializeComponent();
            isNewItem = false;
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (App.isLoggedIn == true)
            {
                ToolbarItem brugerToolbarItem = new ToolbarItem
                {
                    Text = App.BrugernavnOnLogIn,

                    Order = ToolbarItemOrder.Primary,
                    Priority = 0
                };

                this.ToolbarItems.Clear();
                this.ToolbarItems.Add(brugerToolbarItem);
                this.LoginButton.IsVisible = false;
                this.OpretBrugerButton.IsVisible = false;
            }
            

        }

        async void GoToLeaderboard(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoListPage());

        }
    

        async void OpretBruger(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OpretBruger(true)
            {
                BindingContext = new RegisterUser
                {
                }
            });
        }

        async void GoToLogin(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());

        }

        async void ForbindBT(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BlueTooth());
        }

        async void GoToMultiplayer(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Multiplayer());

        }
        async void forbindWebsocket(object sender, EventArgs e)
        {
            WebsocketData data = new WebsocketData();
           await App.TodoManager.GetWebsocketData();
        }
    }
}