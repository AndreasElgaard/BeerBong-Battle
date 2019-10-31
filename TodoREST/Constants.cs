using Xamarin.Forms;

namespace TodoREST
{
	public static class Constants
	{
        // The iOS simulator can connect to localhost. However, Android emulators must use the 10.0.2.2 special alias to your host loopback interface.
        public static string BaseAddress = Device.RuntimePlatform == Device.Android ? "https://projekti4demo.azurewebsites.net" : "https://projekti4demo.azurewebsites.net";
        public static string TodoItemsUrl = BaseAddress + "/api/registers";
    }
}
