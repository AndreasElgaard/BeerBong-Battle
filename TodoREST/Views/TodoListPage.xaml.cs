using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace TodoREST
{
	public partial class TodoListPage : ContentPage
	{
		public TodoListPage ()
		{
			InitializeComponent ();
            
		}

		protected async override void OnAppearing ()
        {
            
			base.OnAppearing ();
            

            listView.ItemsSource = await App.TodoManager.GetTasksAsync ();
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
