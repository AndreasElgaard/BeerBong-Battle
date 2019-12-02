using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoREST.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoREST.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Multiplayer : ContentPage
    {

        bool isNewItem;

        public Multiplayer(bool isNew = false)
        {
            InitializeComponent();

            isNewItem = false;
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
            }

        }

        

        async void OnFindModstander(object sender, EventArgs e)
        {
            QueueModstander modstander = new QueueModstander();
           bool status = await App.TodoManager.GetFirstPlayerInQueue(modstander);
            if (status == false)
            {
                DisplayAlert("Venter på at finde en modstander", "Venter på en modstander joiner dit spil", "ok");
                while (status==false)
                {
                    App.game = new Game();
                    var game = App.game;
                    while (game.players==null)
                    {
                        game = App.game;
                        status = await App.TodoManager.GetFirstPlayerInQueue(modstander);
                    }
                    
                    
                }
            }

            await Navigation.PushAsync(new Multiplayer_2());

        }

    }
}