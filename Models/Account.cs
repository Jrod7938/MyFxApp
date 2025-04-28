namespace MyFxApp.Models {
    /// <summary>
    /// Represents an account on MyFxBook.
    /// </summary>
    public class Account {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int accountId { get; set; }
        public double gain { get; set; }
        public double absGain { get; set; }
        public double daily { get; set; }
        public double monthly { get; set; }
        public double withdrawals { get; set; }
        public double deposits { get; set; }
        public double interest { get; set; }
        public double profit { get; set; }
        public double balance { get; set; }
        public double drawdown { get; set; }
        public double equity { get; set; }
        public double equityPercent { get; set; }
        public bool demo { get; set; }
        public string lastUpdateDate { get; set; }
        public string creationDate { get; set; }
        public string firstTradeDate { get; set; }
        public int tracking { get; set; }
        public int views { get; set; }
        public double commission { get; set; }
        public string currency { get; set; }
        public double profitFactor { get; set; }
        public double pips { get; set; }
        public Server server { get; set; }
        public string WidgetUrl { get; set; }
    }
}