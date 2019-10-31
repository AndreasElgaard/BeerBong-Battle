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

        private string _username;
        private string _password;
        private string _password2;
        private bool _areCredentialsInvalid;
        public OpretBruger(bool isNew=false)
        {
            InitializeComponent();
            isNewItem = isNew;
        }

  

        async void OnOpretBruger(object sender, EventArgs e)
        {
            
            var todoItem = (BrugerTest)BindingContext;
            await App.TodoManager.SaveTaskAsync(todoItem, isNewItem);
            await Navigation.PopAsync();
        }


    }
}