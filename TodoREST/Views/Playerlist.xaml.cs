//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using Xamarin.Forms;
//using Xamarin.Forms.Xaml;

//namespace TodoREST.Views
//{
//    [XamlCompilation(XamlCompilationOptions.Compile)]
//    public partial class Playerlist : ContentPage
//    {
//        public Playerlist()
//        {
//            InitializeComponent();
//        }

//        public class 
//        {
//            private bool _refreshingList = true;
//            private int _count;
//            public PeopleViewModel()
//            {
//                People = new ObservableCollection<Person>();
//                People.CollectionChanged += (s, e) => { _refreshingList = true; };

//                RefreshItemsCommand = new Command(RefreshList);
//            }

//            public int Count { get => _count; set => SetProperty(ref _count, value); }
//            public ObservableCollection<Person> People { get; set; }

//            public ICommand RefreshItemsCommand { get; }


//            public async override Task InitializeAsync()
//            {
//                if (!_refreshingList) return;
//                IsBusy = true;
//                await Task.Delay(System.TimeSpan.FromSeconds(3));

//                var result = new List<Person>
//        {
//            new Person
//            {
//                Name = "Spiller1",
//                Description = "AHHH"
//            },
//            new Person
//            {
//                Name = "Spiller2",
//                Description = "AHHHHHHHHHH"
//            },
//            new Person
//            {
//                Name = "Spiller3",
//                Description = "AHHHHHHHHH"
//            }
//        };

//                foreach (var item in result)
//                    People.Add(item);

//                _refreshingList = false;
//                IsBusy = false;
//            }

//            private void RefreshList()
//            {
//                var currentItems = People.ToList();

//                People.Clear();

//                var count = 0;
//                foreach (var item in currentItems)
//                {
//                    if (count >= Count) return;
//                    People.Add(item);
//                    count++;
//                }
//            }

//        }
//    }
//}