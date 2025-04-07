using MyFxApp.Views;

namespace MyFxApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // register views
            Routing.RegisterRoute(nameof(AccountsPage), typeof(AccountsPage));
            Routing.RegisterRoute(nameof(AccountDetailPage), typeof(AccountDetailPage));
        }
    }
}
