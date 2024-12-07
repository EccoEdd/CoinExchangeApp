using CoinApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Token = CoinApp.Models.Token;

namespace CoinApp.Services
{
	public class ApiService
	{
		private HttpClient _httpClient;
		public ApiService()
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress =  new Uri(ApiConfig.BaseUrl);
		}

		public async Task<Token> LoginAsync(UserLogIn user){
			var token = new Token();

			var json = System.Text.Json.JsonSerializer.Serialize(user);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await _httpClient.PostAsync("access/log-in", content);

			if (response.IsSuccessStatusCode)
			{
				var responseData = await response.Content.ReadAsStringAsync();
				token = JsonConvert.DeserializeObject<Token>(responseData);

				return token;
			}
			else
			{
				Console.WriteLine("XD");
				return null;
			}
		}

		public async Task<bool> LogoutAsync(Token token)
		{
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
			var response = await _httpClient.PostAsync("access/log-out", null);

			return response.IsSuccessStatusCode;
		}

		public async Task<CoinList> GetCoins()
		{
			var coinList = new CoinList();

			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionManager.Instance.token.access_token);
			var response = await _httpClient.PostAsync("coins/index", null);
			if (response.IsSuccessStatusCode){
				var responseData = await response.Content.ReadAsStringAsync();
				coinList = JsonConvert.DeserializeObject<CoinList>(responseData);

				return coinList;
			}
			else {
				return null;
			}
		}
	}
}
