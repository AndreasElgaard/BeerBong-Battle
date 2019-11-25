using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoREST.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Multiplayer_2 : ContentPage
    {
        public Multiplayer_2()
        {
            InitializeComponent();
            Timer1();
            modstanderentry.Text = App.modstander.brugerNavn;
        }


        public async void Timer1()
        {

            for (int i = 0; i < 31; i++)
            { 
                TTimer.Text = i.ToString(); 

                await Task.Delay(1000);

                if (i==30)
                {
                    TTimer.IsVisible = false;
                    fyldop.IsVisible = false;
                    break;
                }
                
            }
        }
    }
    
}
