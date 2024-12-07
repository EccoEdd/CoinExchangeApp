using CoinApp.Models;

namespace CoinApp.Views;

public partial class ChangePage : ContentPage
{
	private string name;
	private decimal value;
	public ChangePage(Coin coin)
	{
		InitializeComponent();

		this.value = coin.usd_exchange_rate;
		this.name = coin.short_name;

		exchangeRateLabel.Text = $"1 {coin.short_name} = {coin.usd_exchange_rate:N4} USD";
		currentCurrency.Text = this.name;

	}

	private void OnAmountEntryTextChanged(object sender, TextChangedEventArgs e)
	{
		if (decimal.TryParse(amountEntry.Text, out decimal amount))
		{
			decimal convertedAmount = amount * this.value;
			ConvertedAmountUSD.Text = $"{convertedAmount:N2}";
		}
		else
		{
			ConvertedAmountUSD.Text = "0.00";
		}
	}

}