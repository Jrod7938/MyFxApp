using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyFxApp.Models;
using MyFxApp.Services;
using MyFxApp.Views;
using System.Collections.ObjectModel;

namespace MyFxApp.ViewModel {

    [QueryProperty(nameof(Session), "session")]
    public partial class AccountsViewModel : ObservableObject {
        private readonly IMyFxBookApiService _api;
        private readonly ILocalStorageService _localStorage;

        [ObservableProperty]
        private string session;

        public ObservableCollection<Account> Accounts { get; } = new();

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private Account selectedAccount;

        public AccountsViewModel(IMyFxBookApiService api, ILocalStorageService localStorage) {
            _api = api;
            _localStorage = localStorage;
        }

        [RelayCommand]
        public async Task LoadAccountsAsync() {
            if (string.IsNullOrEmpty(Session))
                return;

            IsBusy = true;
            try {
                List<Account> accounts;
                var lastUpdate = await _localStorage.GetLastUpdateTimeAsync();
                if (lastUpdate.HasValue && DateTime.UtcNow - lastUpdate.Value < TimeSpan.FromMinutes(1)) {
                    accounts = await _localStorage.GetAccountsAsync();
                } else {
                    accounts = await _api.GetAccountsAsync(Session);
                    await _localStorage.SaveAccountsAsync(accounts);
                }
                RefreshAccountsList(accounts);
            } finally {
                IsBusy = false;
            }
        }

        private void RefreshAccountsList(List<Account> list) {
            Accounts.Clear();
            foreach (var account in list) {
                // Compute the widget URL using the current Session and account id.
                account.WidgetUrl = $"https://widgets.myfxbook.com/api/get-custom-widget.png?session={Session}&id={account.id}&width=600&height=400&bart=1&linet=0&bgColor=000000&gridColor=BDBDBD&lineColor=00CB05&barColor=FF8D0A&fontColor=FFFFFF&chartbgc=474747";
                Accounts.Add(account);
            }
        }

        // Property changed handler for SelectedAccount
        partial void OnSelectedAccountChanged(Account value) {
            if (value != null) {
                _ = NavigateToDetailAsync(value);
            }
        }

        private async Task NavigateToDetailAsync(Account account) {
            // Build the URI with exact query keys (case-sensitive)
            string uri = $"{nameof(AccountDetailPage)}?Session={Session}&AccountId={account.id}";
            try {
                await Shell.Current.GoToAsync(uri);
            } catch (System.Runtime.InteropServices.COMException) {
                // Optional: Retry navigation after a brief delay
                await Task.Delay(100);
                try {
                    await Shell.Current.GoToAsync(uri);
                } catch (Exception ex) {
                    System.Diagnostics.Debug.WriteLine($"Navigation error: {ex.Message}");
                    await Shell.Current.DisplayAlert("Navigation Error", ex.Message, "OK");
                }
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine($"Navigation error: {ex.Message}");
                await Shell.Current.DisplayAlert("Navigation Error", ex.Message, "OK");
            } finally {
                // Clear selection so the same account can be selected again later.
                SelectedAccount = null;
            }
        }


        [RelayCommand]
        public async Task Logout() {
            if (!string.IsNullOrEmpty(Session))
                await _api.LogoutAsync(Session);

            // Navigate back to the Login page.
            await Shell.Current.GoToAsync("///LoginPage");
        }
    }
}
