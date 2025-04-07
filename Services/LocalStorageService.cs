using MyFxApp.Models;
using SQLite;

namespace MyFxApp.Services {
    public class LocalStorageService : ILocalStorageService {

        private readonly SQLiteAsyncConnection _db;

        public LocalStorageService() {
            var path = Path.Combine(FileSystem.AppDataDirectory, "localdata.db3");
            _db = new SQLiteAsyncConnection(path);
            _db.CreateTableAsync<AccountEntity>().Wait();
            _db.CreateTableAsync<CacheTimestamp>().Wait();
        }

        public async Task<List<Account>> GetAccountsAsync() {
            var list = await _db.Table<AccountEntity>().ToListAsync();
            return list.Select(accountEntity => new Account {
                id = accountEntity.Id,
                name = accountEntity.Name,
                balance = accountEntity.Balance,
                profit = accountEntity.Profit,
                gain = accountEntity.Gain,
                monthly = accountEntity.Monthly,
                deposits = accountEntity.Deposits,
                withdrawals = accountEntity.Withdrawals,
                WidgetUrl = accountEntity.WidgetUrl
            }).ToList();
        }

        public async Task<DateTime?> GetLastUpdateTimeAsync() {
            var stamp = await _db.Table<CacheTimestamp>().FirstOrDefaultAsync();
            return stamp?.Time;
        }

        public async Task SaveAccountsAsync(List<Account> accounts) {
            await _db.DeleteAllAsync<AccountEntity>();
            var entities = accounts.Select(account => new AccountEntity {
                Id = account.id,
                Name = account.name,
                Balance = account.balance,
                Profit = account.profit,
                Gain = account.gain,
                Monthly = account.monthly,
                Deposits = account.deposits,
                Withdrawals = account.withdrawals,
                WidgetUrl = account.WidgetUrl
            });
            await _db.InsertAllAsync(entities);
            await UpdateLastUpdateTimeAsync(DateTime.UtcNow);
        }

        public async Task UpdateLastUpdateTimeAsync(DateTime time) {
            await _db.DeleteAllAsync<CacheTimestamp>();
            await _db.InsertAsync(new CacheTimestamp { Id = 1, Time = time });
        }
    }
}