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
    public partial class OpretBruger : ContentPage
    { 
        bool isNewItem;
        private string password1_;
        private string password2_;

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

        async void OnOpretBruger(object sender, EventArgs e)
        {
            

            password1_ = Password.Text;
            password2_ = Password2.Text;

            if (password1_ != password2_)
            {
                ErrorLabel.Text = "Passwords matcher ikke";
                
            }
            else
            {
                OpretBrugerSucces();
            }

           // var todoItem = (OpretBrugerModel)BindingContext;
            
        }

        public void OpretBrugerSucces()
        {
            var bruger = new OpretBrugerModel
            {
                navn = Brugernavn.Text,
                password = Password.Text
            };

            string brugernavnonopret;
            brugernavnonopret = Brugernavn.Text;
            //  App.TodoManager.SaveOpretBruger(bruger, isNewItem);
            DisplayAlert("Bruger succesfuldt oprettet!", "Du er oprettet som: " + brugernavnonopret, "OK");
            
            Navigation.PopAsync();
        }
        
    }
}