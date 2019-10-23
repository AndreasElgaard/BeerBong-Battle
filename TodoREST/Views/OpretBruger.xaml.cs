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
    public partial class OpretBruger : INotifyPropertyChanged
    {
        private bool isNewItem;
        private string _username;
        private string _password;
        private string _password2;
        private bool _areCredentialsInvalid;
        public OpretBruger(bool isNew=false)
        {
            InitializeComponent();
            isNewItem = false;
        }

        private bool BrugerOprettet(string username, string password, string password2)
        {
            if (string.IsNullOrEmpty(username)
                || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(password2))
            {
                return false;
            }

            return username.ToLowerInvariant() == "prøv igen"
                   && password.ToLowerInvariant() == "******" && password2.ToLowerInvariant() == "******";
        }
        async void OnOpretBruger(object sender, EventArgs e)
        {

            _password = Password;
            _password2 = Password2;
            if (_password !=_password2)
            {
                await DisplayAlert("Alert", "Password patcher ikke", "Prøv Igen");
            }

            else
            {
                await Navigation.PopAsync();
            }
        }

            public class LabelModel
        {
            
            public bool LabelCheck { get; set; }
        }

        public string Username
        {
            get => _username;
            set
            {
                if (value == _username) return;
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (value == _password) return;
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string Password2
        {
            get => _password;
            set
            {
                if (value == _password2) return;
                _password2 = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        
        public bool AreCredentialsInvalid
        {
            get => _areCredentialsInvalid;
            set
            {
                if (value == _areCredentialsInvalid) return;
                _areCredentialsInvalid = value;
                OnPropertyChanged(nameof(AreCredentialsInvalid));
                DisplayAlert("Alert", "Password patcher ikke", "Prøv Igen");
            }
        }
    }
}