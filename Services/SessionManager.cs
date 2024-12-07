using CoinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinApp.Services
{
	public class SessionManager
	{
		private static readonly Lazy<SessionManager> _instance = new Lazy<SessionManager>(() => new SessionManager());
		public Token token { get; private set; }
		private SessionManager() { }
		public static SessionManager Instance => _instance.Value;
		public void SetToken(Token token)
		{
			this.token = token;
		}
		public void ClearToken()
		{
			this.token = null;
		}

		public bool IsAuthenticated => this.token != null;
	}
}
