using CoinApp.Models;
using CoinApp.Services;

namespace CoinApp.Views;
public partial class LogInPage : ContentPage
{
	private ApiService apiService = new ApiService();
	public LogInPage()
	{
		InitializeComponent();
	}

	private async void OnClickLogIn(object sender, EventArgs e){
		if (this.UsernameEntry.Text == null && this.UsernameEntry.Text == null){
			_ = DisplayAlert("Warning", "Please check your data", "ok");
			return;
		}

		var userTo = new UserLogIn
		{
			name = this.UsernameEntry.Text,
			password = this.PasswordEntry.Text,
		};

		var token = await apiService.LoginAsync(userTo);

		if (token == null) {
			_ = DisplayAlert("Unauthorized", "Invalid credentials", "I understand");
			return;
		}

		SessionManager.Instance.SetToken(token);
		//await Navigation.PushAsync(new HomePage());
		Application.Current.MainPage = new NavigationPage(new HomePage());
	}
}