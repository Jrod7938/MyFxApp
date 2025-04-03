namespace MyFxApp.Services {
    public class Account {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int accountId { get; set; }
        public double gain { get; set; }
        public double absGain { get; set; }
        public long daily { get; set; }
        public long monthly { get; set; }
        public long withdrawals { get; set; }
        public long deposits { get; set; }
        public long interest { get; set; }
        public long profit { get; set; }
        public long balance { get; set; }
        public long drawdown { get; set; }
        public long equity { get; set; }
        public int equityPercent { get; set; }
        public bool demo { get; set; }
        public string lastUpdateDate { get; set; }
        public string creationDate { get; set; }
        public string firstTradeDate { get; set; }
        public int tracking { get; set; }
        public int views { get; set; }
        public long commission { get; set; }
        public string currency { get; set; }
        public double profitFactor { get; set; }
        public long pips { get; set; }
        public string invitationUrl { get; set; }
        public Server server { get; set; }
    }
}