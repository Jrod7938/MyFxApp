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
    }
}
