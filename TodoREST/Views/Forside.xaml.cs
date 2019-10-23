using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        async void GoToLeaderboard(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoListPage());

        }
        async void OpretBruger(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OpretBruger());

        }
    }
}