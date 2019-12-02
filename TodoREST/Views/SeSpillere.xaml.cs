using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite;
using TodoREST.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoREST.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeSpillere : ContentPage
    {
        private ListView _listView;
        private string _dbPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "myDB.db3");
        public SeSpillere()
        {
            this.Title = "Spillere";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();
            _listView = new ListView();
            _listView.ItemsSource = db.Table<Players>().OrderBy(x => x.Name).ToList();

            stackLayout.Children.Add(_listView);

            Content = stackLayout;
        }
    }
}