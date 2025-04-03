using MyFxApp.ViewModel;

namespace MyFxApp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}