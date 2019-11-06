using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoREST.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        bool isNewItem;

        public LoginPage(bool isNew = false)
        {
            InitializeComponent();
            isNewItem = isNew;
        }



        async void OnLogin(object sender, EventArgs e)
        {

            
            await Navigation.PopAsync();
        }

        async void OnOpretBrugerFromLogin(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new OpretBruger(true)
            {
                BindingContext = new BrugerTest
                {
                    
                }
            });
        }


    }
}