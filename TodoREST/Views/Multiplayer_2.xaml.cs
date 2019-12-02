using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TodoREST.Data;
using TodoREST.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoREST.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Multiplayer_2 : ContentPage
    {
        double playertid;
        double modstandertid;
        public Multiplayer_2()
        {
            InitializeComponent();
            Timer1();
            modstanderentry.Text = App.modstander.brugerNavn;
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

            KlarButton.IsVisible = false;
        }


        public async void Timer1()
        {

            for (int i = 0; i < 31; i++)
            { 
                TTimer.Text = i.ToString(); 

                await Task.Delay(1000);

                if (i==10)
                {
                    TTimer.IsVisible = false;
                    fyldop.IsVisible = false;
                   // WaitForBeerBongToFill();
                   Timer2();
                    break;
                }
                
            }
        }

        public async void Timer2()
        {

            for (int i = 0; i < 181; i++)
            {
                DrikTimer.Text = i.ToString();

                await Task.Delay(1000);

                if (i == 10)
                {
                    List<WebsocketData> data = new List<WebsocketData>();
                    //data = await App.TodoManager.GetWebsocketData();
                    Stats playerstats = new Stats()
                    {
                        playerId = App.player.PlayerId,
                       // time = double.Parse(data[0].time)
                       time = 15
                    };
                    int id = App.player.PlayerId;
                    await App.TodoManager.PushStats(playerstats);
                    await App.TodoManager.PushtoLeaderboard(id);
                    

                    var gameresult = await App.TodoManager.GetGameResult(App.game.gameId);
                    var result = App.gameresultat;
                    

                    foreach (var p in gameresult)
                    {
                        if (p.playerid == App.player.PlayerId)
                        {
                            userTid.Text = "Din tid: " + p.time.ToString();
                             playertid = p.time;
                        }

                        if (p.playerid == App.modstander.Playerid)
                        {
                            modstanderTid.Text = App.modstander.brugerNavn + ": " + p.time.ToString();
                             modstandertid = p.time;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (playertid<modstandertid)
                    {
                        VinderEntry.Text = "Vinderen er: " + App.BrugernavnOnLogIn;
                    }
                    else
                    {
                        VinderEntry.Text = "Vinderen er: " + App.modstander.brugerNavn;
                    }
                    break;
                }


            }
        }

        public async void WaitForBeerBongToFill()
        {
            List<WebsocketData> data = new List<WebsocketData>();
            data = await App.TodoManager.GetWebsocketData();
               if (data[0].state != "Fullstate")
               {
                   await DisplayAlert("Fyld din bong op", "Din bong er ikke fuld, fyld venligst 33cl øl i", "ok");
                   KlarButton.IsVisible = false;
               }
               else
               {
                   KlarButton.IsVisible = true;
               }
            
        }
    }
    
}
