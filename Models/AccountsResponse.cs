using MyFxApp.Services;

namespace MyFxApp.Models {
    /// <summary>
    /// Represents the response from the MyFxBook API for accounts.
    /// </summary>
    public class AccountsResponse {
        public bool error { get; set; }
        public string message { get; set; }
        public List<Account> accounts { get; set; }
    }
}