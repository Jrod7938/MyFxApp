using MyFxApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

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

        public string GetCustomWidgetUrl(string session, int accountId, int width = 300, int height = 200) {
            return $"https://widgets.myfxbook.com/api/get-custom-widget.png?session={session}&id={accountId}" +
               $"&width={width}&height={height}&bart=1&linet=0&bgColor=000000&gridColor=BDBDBD" +
               $"&lineColor=00CB05&barColor=FF8D0A&fontColor=FFFFFF&chartbgc=474747";
        }

        public async Task<List<DataDaily>> GetDataDailyAsync(string session, int accountId, DateTime start, DateTime end) {
            string startStr = start.ToString("yyyy-MM-dd");
            string endStr = end.ToString("yyyy-MM-dd");
            var url = $"https://www.myfxbook.com/api/get-data-daily.json?session={session}&id={accountId}&start={startStr}&end={endStr}";
            var json = await _client.GetStringAsync(url);
            var result = JsonSerializer.Deserialize<DataDailyResponse>(json);

            // dataDaily is a List<List<DataDaily>> so flatten it
            var dailyList = new List<DataDaily>();
            if (result?.dataDaily != null) {
                foreach (var subList in result.dataDaily)
                    dailyList.AddRange((IEnumerable<DataDaily>)subList);
            }
            return dailyList;
        }

        public async Task<List<HistoryEntry>> GetHistoryAsync(string session, int accountId) {
            var url = $"https://www.myfxbook.com/api/get-history.json?session={session}&id={accountId}";
            var json = await _client.GetStringAsync(url);
            var result = JsonSerializer.Deserialize<HistoryResponse>(json);
            return result?.history ?? new List<HistoryEntry>();
        }

        public async Task<List<OpenOrder>> GetOpenOrdersAsync(string session, int accountId) {
            var url = $"https://www.myfxbook.com/api/get-open-orders.json?session={session}&id={accountId}";
            var json = await _client.GetStringAsync(url);
            var result = JsonSerializer.Deserialize<OpenOrdersResponse>(json);
            return result?.openOrders ?? new List<OpenOrder>();
        }

        public async Task<List<OpenTrade>> GetOpenTradesAsync(string session, int accountId) {
            var url = $"https://www.myfxbook.com/api/get-open-trades.json?session={session}&id={accountId}";
            var json = await _client.GetStringAsync(url);
            var result = JsonSerializer.Deserialize<OpenTradesResponse>(json);
            return result?.openTrades ?? new List<OpenTrade>();
        }

        public async Task<string> LoginAsync(string email, string password) {
            var url = $"https://www.myfxbook.com/api/login.json?email={email}&password={password}&debug=1";
            var json = await _client.GetStringAsync(url);
            var result = JsonSerializer.Deserialize<LoginResponse>(json);
            if (result != null && !result.error) 
                return result.session;
            throw new Exception($"Login Failed: {result.message}");
        }

        public async Task LogoutAsync(string session) {
            var url = $"https://www.myfxbook.com/api/logout.json?session={session}";
            await _client.GetStringAsync(url);
        }
    }
}
