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
        private OpretBrugerModel LoginBruger;
        private string _password;
        private string _brugernavn;

        public LoginPage(bool isNew = false)
        {
            InitializeComponent();
            isNewItem = isNew;
        }




        async void OnLogin(object sender, EventArgs e)
        {

            var LoginBruger = await App.TodoManager.GetLoginDataAsync();

            int AntalBrugere = LoginBruger.Count;

            _password = Password.Text;
            _brugernavn = Brugernavn.Text;

            for (int i = 0; i < AntalBrugere; i++)
            {
                if (_brugernavn == LoginBruger[i].navn && _password == LoginBruger[i].password)
                {
                    _brugernavn = LoginBruger[i].navn;
                    

                    await DisplayAlert("Login succesfuldt!", "Du er logget ind som: " + _brugernavn, "OK");

                    ToolbarItem brugerToolbarItem = new ToolbarItem
                    {
                        Text = "brugernavn:" + _brugernavn,

                        Order = ToolbarItemOrder.Primary,
                        Priority = 0
                    };

                        this.ToolbarItems.Add(brugerToolbarItem);
                        App.isLoggedIn = true;
                        App.BrugernavnOnLogIn = _brugernavn;
                        break;


                }
                
                
                
            }
            //Hvis brugernavn og password ikke stemmeroverens
            if (App.isLoggedIn==false)
            {
                await DisplayAlert("Brugernavn eller password forkert", "Prøv igen!", "OK");
            }
            else
            {
                await Navigation.PushAsync(new Forside(true));
            }
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