using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace TodoREST
{
	public partial class TodoListPage : ContentPage
    {
        private string _navn;
        private string _tid;
        private int _count;
		public TodoListPage ()
		{
			InitializeComponent ();
            
		}

		protected async override void OnAppearing ()
        {
            
			base.OnAppearing ();
            List<OnlineLeaderboard> leaderboard = new List<OnlineLeaderboard>();


            

           

           leaderboard = await App.TodoManager.GetOnlineLeaderboardAsync();
           listView.ItemsSource = leaderboard;
            _count = leaderboard.Count;

            for (int i = 0; i < _count; i++)
            {
                leaderboard.Add(new OnlineLeaderboard(){navn=leaderboard[i].navn});
            }
		}

		//async void OnAddItemClicked (object sender, EventArgs e)
		//{
  //          await Navigation.PushAsync(new TodoItemPage(true)
  //          {
  //              BindingContext = new BrugerTest
  //              {
                    

  //              }
  //          });
		//}

		//async void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
		//{
  //          await Navigation.PushAsync(new TodoItemPage
  //          {
  //              BindingContext = e.SelectedItem as BrugerTest
  //          });
		//}
	}
}
