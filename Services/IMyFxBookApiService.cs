using MyFxApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFxApp.Services {
    public interface IMyFxBookApiService {

        Task<string> LoginAsync(string email, string password);
        Task LogoutAsync(string session);
        Task<List<Account>> GetAccountsAsync(string session);
        Task<List<OpenTrade>> GetOpenTradesAsync(string session, int accountId);
        Task<List<OpenOrder>> GetOpenOrdersAsync(string session, int accountId);
        Task<List<HistoryEntry>> GetHistoryAsync(string session, int accountId);
        Task<List<DataDaily>> GetDataDailyAsync(string session, int accountId, DateTime start, DateTime end);
        string GetCustomWidgetUrl(string session, int accountId, int width = 300, int height = 200);
    }
}
