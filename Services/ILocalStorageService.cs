using MyFxApp.Models;

namespace MyFxApp.Services {
    public interface ILocalStorageService {
        Task SaveAccountsAsync(List<Account> accounts);
        Task<List<Account>> GetAccountsAsync();
        Task<DateTime?> GetLastUpdateTimeAsync();
        Task UpdateLastUpdateTimeAsync(DateTime time);
    }
}