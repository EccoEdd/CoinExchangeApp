using CoinApp.Views;

namespace CoinApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			//MainPage = new AppShell();
			MainPage = new NavigationPage(new LogInPage());
		}
	}
}
