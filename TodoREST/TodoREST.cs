using TodoREST.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TodoREST
{
	public class App : Application
	{
		public static TodoItemManager TodoManager { get; private set; }


        public static bool isLoggedIn = false;

        public static string BrugernavnOnLogIn;
       

        

        public App ()
		{
			TodoManager = new TodoItemManager (new RestService ());
            
			MainPage = new NavigationPage (new Forside ());
		}

        

		protected override void OnStart ()
        {
            
        }

		protected override void OnSleep ()
		{
			
		}

		protected override void OnResume ()
		{
			
		}
	}
}

