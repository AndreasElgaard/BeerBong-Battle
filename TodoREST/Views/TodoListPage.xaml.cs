using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using TodoREST.Models;
using Xamarin.Forms;


namespace TodoREST
{
	public partial class TodoListPage : ContentPage, INotifyPropertyChanged
    {
 
        List<OnlineLeaderboard> leaderboard = new List<OnlineLeaderboard>();


        public TodoListPage ()
		{
            InitializeComponent ();
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

		protected async override void OnAppearing ()
        {
            
			base.OnAppearing ();
            
            leaderboard = await App.TodoManager.GetOnlineLeaderboardAsync();
            LeaderboardData.ItemsSource = leaderboard;
        }
    }
}
