using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoREST.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Forms.NavigationPage;

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
            string logisvar;
            tænker.IsRunning = true;
            var login = new LoginUser()
            {
                userName = Brugernavn.Text,
                passWord = Password.Text
            };
            string username = Brugernavn.Text;
            
           bool status = await App.TodoManager.GetLoginDataAsync(login);


           if (status==true)
           {
               tænker.IsRunning = false;
                await DisplayAlert("Login succesfuldt!", "Du er logget ind som: " + username, "OK");
               ToolbarItem brugerToolbarItem = new ToolbarItem
               {
                   Text = "brugernavn:" + username,

                   Order = ToolbarItemOrder.Primary,
                   Priority = 0
               };

               this.ToolbarItems.Add(brugerToolbarItem);
               App.isLoggedIn = true;
               App.BrugernavnOnLogIn = username;
               await Navigation.PopAsync();

           }
           else
           {
               tænker.IsRunning = false;
               await DisplayAlert("Login fejl!", "Brugernavn eller password forkert. Prøv igen", "OK");
           }
            

            

        }

    }
}