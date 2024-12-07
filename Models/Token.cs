using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinApp.Models
{
	public class Token
	{
		public string access_token {  get; set; }
		public string token_type { get; set; }
		public string message { get; set; }
	}
}
