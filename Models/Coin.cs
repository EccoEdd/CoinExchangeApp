using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinApp.Models
{
	public class Coin
	{
		public int Id { get; set; }
		public string short_name { get; set; }
		public string full_name { get; set; }
		public decimal usd_exchange_rate { get; set; }
		public DateTime created_at { get; set; }
		public DateTime updated_at { get; set; }
	}
}
