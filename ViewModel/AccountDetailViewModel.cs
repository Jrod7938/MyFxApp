using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microcharts;
using MyFxApp.Models;
using MyFxApp.Services;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.Globalization;

namespace MyFxApp.ViewModel {
    public partial class AccountDetailViewModel : ObservableObject, IQueryAttributable {
        private readonly IMyFxBookApiService _api;

        [ObservableProperty]
        private string session;

        [ObservableProperty]
        private int accountId;

        [ObservableProperty]
        private Chart dailyChart;

        [ObservableProperty]
        private bool isBusy;

        public ObservableCollection<OpenTrade> OpenTrades { get; } = new();
        public ObservableCollection<OpenOrder> OpenOrders { get; } = new();
        public ObservableCollection<HistoryEntry> History { get; } = new();

        public AccountDetailViewModel(IMyFxBookApiService api) {
            _api = api;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query) {
            if (query.TryGetValue("Session", out object sessionObj)) {
                Session = sessionObj?.ToString();
            }
            if (query.TryGetValue("AccountId", out object accountIdObj)) {
                if (int.TryParse(accountIdObj?.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out int id)) {
                    AccountId = id;
                }
            }
            _ = LoadAccountDetails();
        }

        [RelayCommand]
        public async Task LoadAccountDetails() {
            if (string.IsNullOrEmpty(Session) || AccountId <= 0)
                return;
            IsBusy = true;
            try {
                // Load open trades
                var trades = await _api.GetOpenTradesAsync(Session, AccountId);
                OpenTrades.Clear();
                foreach (var t in trades) OpenTrades.Add(t);

                // Load open orders
                var orders = await _api.GetOpenOrdersAsync(Session, AccountId);
                OpenOrders.Clear();
                foreach (var o in orders) OpenOrders.Add(o);

                // Load history
                var history = await _api.GetHistoryAsync(Session, AccountId);
                History.Clear();
                foreach (var h in history) History.Add(h);

                // Load daily data for Microcharts (example: last 90 days)
                var daily = await _api.GetDataDailyAsync(Session, AccountId, DateTime.UtcNow.AddDays(-90), DateTime.UtcNow);

                // Build a chart (e.g., line chart)
                var entries = daily.Select(d => new ChartEntry((float)d.balance) {
                    // Instead of d.date directly, parse it and format it more nicely
                    Label = DateTime.Parse(d.date).ToString("MM/dd"),
                    ValueLabel = d.balance.ToString("F2"),
                    Color = SKColor.Parse("#FF8D0A")
                }).ToList();

                float minValue = daily.Any() ? (float)daily.Min(x => x.balance) - 10 : 0; // small buffer
                float maxValue = daily.Any() ? (float)daily.Max(x => x.balance) + 10 : 10;

                if (entries.Any()) {
                    DailyChart = new LineChart {
                        Entries = entries,
                        LineMode = LineMode.Spline,
                        PointMode = PointMode.Circle,
                        LineSize = 4,
                        PointSize = 6,
                        LabelTextSize = 18,
                        LabelOrientation = Orientation.Horizontal,
                        ValueLabelOrientation = Orientation.Horizontal,
                        MinValue = minValue,
                        MaxValue = maxValue,
                        BackgroundColor = SKColors.WhiteSmoke
                    };
                }
            } finally {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task GoBack() {
            await Shell.Current.GoToAsync("..");
        }
    }
}
