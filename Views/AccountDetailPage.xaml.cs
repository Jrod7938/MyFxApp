using MyFxApp.ViewModel;

namespace MyFxApp.Views;

public partial class AccountDetailPage : ContentPage
{
	public AccountDetailPage(AccountDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override async void OnNavigatedTo(NavigatedToEventArgs args) {
        base.OnNavigatedTo(args);
        var vm = BindingContext as AccountDetailViewModel;
        if (vm != null) {
            await vm.LoadAccountDetailsCommand.ExecuteAsync(null);
        }
    }
}