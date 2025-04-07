using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyFxApp.Services;
using MyFxApp.Views;
using System.Diagnostics;

namespace MyFxApp.ViewModel {
    public partial class LoginViewModel : ObservableObject {

        private readonly IMyFxBookApiService _apiService;

        public LoginViewModel(IMyFxBookApiService apiService) {
            _apiService = apiService;
            Debug.WriteLine("Login ViewModel Created");
        }

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string errorMessage;

        [RelayCommand]
        async Task LoginAsync() {
            try {
                Debug.WriteLine("LoginAsync Triggered");
                var session = await _apiService.LoginAsync(Email, Password);
                Debug.WriteLine($"Session: {session}");
                await Shell.Current.GoToAsync($"{nameof(AccountsPage)}?session={session}");
            } catch (Exception exception) {
                ErrorMessage = exception.Message;
                Debug.WriteLine($"Error: {exception.Message}");
            }
        }
    }
}