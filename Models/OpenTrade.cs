namespace MyFxApp.Models {
    public class OpenTrade {
        public string openTime { get; set; }
        public string symbol { get; set; }
        public string action { get; set; }
        public double openPrice { get; set; }
        public double tp { get; set; }
        public double sl { get; set; }
        public double profit { get; set; }
        public double pips { get; set; }
        public double swap { get; set; }
    }
}