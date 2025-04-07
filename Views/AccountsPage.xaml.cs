using MyFxApp.ViewModel;

namespace MyFxApp.Views;

public partial class AccountsPage : ContentPage {
    public AccountsPage(AccountsViewModel vm) {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args) {
        base.OnNavigatedTo(args);
        if (BindingContext is AccountsViewModel vm) {
            await vm.LoadAccountsAsync();
        }
    }
}