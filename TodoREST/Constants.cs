using Xamarin.Forms;

namespace TodoREST
{
	public static class Constants
	{
        // The iOS simulator can connect to localhost. However, Android emulators must use the 10.0.2.2 special alias to your host loopback interface.
        public static string BaseAddress = Device.RuntimePlatform == Device.Android ? "https://jsonplaceholder.typicode.com" : "https://jsonplaceholder.typicode.com";
        public static string TodoItemsUrl = BaseAddress + "/posts";
    }
}
