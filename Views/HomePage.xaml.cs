using CoinApp.Models;
using CoinApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CoinApp.Views;

public partial class HomePage : ContentPage
{
	private ApiService apiService = new ApiService();
	private CoinList coins = new CoinList();
	public ObservableCollection<Coin> CoinList {  get; set; } = new ObservableCollection<Coin>();
	public HomePage()
	{
		InitializeComponent();
		dateUpd.Text = $"Last Time Updated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}";
		this.getData();
	}

	private async void getData()
	{
		if(SessionManager.Instance.IsAuthenticated) {
			var data = await apiService.GetCoins();
			this.coins = data;

			CoinList.Clear();
			foreach(var coin in coins.Coins)
			{
				CoinList.Add(coin);
			}

			collectionCoins.ItemsSource = CoinList;
		}
		else
		{
			_ = DisplayAlert("Error", "An error has acourred, please re-start the app", "I understand");
			Application.Current.MainPage = new NavigationPage(new LogInPage());
		}
	}

	private async void OnTapped(object sender, EventArgs e)
	{
		var frame = sender as Frame;
		var selectedCoin = frame?.BindingContext as Coin;

		if (selectedCoin != null)
			await Navigation.PushAsync(new ChangePage(selectedCoin));

		return;
	}

	public async void OnLogOut(object sender, EventArgs e)
	{
		bool confirmed = await Application.Current.MainPage.DisplayAlert("Login Out", "Are you sure you want to end this session?", "Yes", "No");
		if (confirmed)
		{
			await apiService.LogoutAsync(SessionManager.Instance.token);

			SessionManager.Instance.ClearToken();
			Application.Current.MainPage = new NavigationPage(new LogInPage());
		}
	}
}