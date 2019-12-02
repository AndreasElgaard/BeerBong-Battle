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

namespace TodoREST.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OpretBruger : ContentPage
    { 
        bool isNewItem;
        public string password1_;
        public string password2_;

        public OpretBruger(bool isNew=false)
        {
            InitializeComponent();
            isNewItem = isNew;
            if (App.isLoggedIn==true)
            {
                ToolbarItem brugerToolbarItem = new ToolbarItem
                {
                    Text = App.BrugernavnOnLogIn,

                    Order = ToolbarItemOrder.Primary,
                    Priority = 0
                };

                this.ToolbarItems.Add(brugerToolbarItem);
            }
            
        }

        
        void OnOpretBruger(object sender, EventArgs e)
        {
            password1_ = Password.Text;
            password2_ = Password2.Text;

           bool status = PasswordCheck();
           if (status!=true)
           {
               ErrorLabel.Text = "Passwords matcher ikke";
           }
           else
           { 
               OpretBrugerSucces();
           }
        }

        public bool PasswordCheck()
        {
            if (password1_ != password2_)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void OpretBrugerSucces()
        {
            var bruger = new RegisterUser()
            {
                userName = Brugernavn.Text,
                passWord = Password.Text
            };

            string brugernavnonopret;
            brugernavnonopret = Brugernavn.Text;
            App.TodoManager.SaveOpretBruger(bruger);
            DisplayAlert("Bruger succesfuldt oprettet!", "Du er oprettet som: " + brugernavnonopret, "OK");
            
            Navigation.PopAsync();
        }
        
    }
}