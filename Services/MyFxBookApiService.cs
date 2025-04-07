using MyFxApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyFxApp.Services {
    public class MyFxBookApiService : IMyFxBookApiService {

        private readonly HttpClient _client = new HttpClient();

        public async Task<List<Account>> GetAccountsAsync(string session) {
            var url = $"https://www.myfxbook.com/api/get-my-accounts.json?session={session}";
            var json = await _client.GetStringAsync(url);
            var result = JsonSerializer.Deserialize<AccountsResponse>(json);

            if (result != null && !result.error)
                return result.accounts;
            throw new Exception("Failed to return Account");
        }

        public async Task<string> LoginAsync(string email, string password) {
            var url = $"https://www.myfxbook.com/api/login.json?email={email}&password={password}";
            var json = await _client.GetStringAsync(url);
            var result = JsonSerializer.Deserialize<LoginResponse>(json);
            if (result != null && !result.error) 
                return result.session;
            throw new Exception("Login Failed");
        }

        public async Task LogoutAsync(string session) {
            var url = $"https://www.myfxbook.com/api/logout.json?session={session}";
            await _client.GetStringAsync(url);
        }
    }
}
