namespace MyFxApp.Models {
    public class OpenOrder {
        public string openTime { get; set; }
        public string symbol { get; set; }
        public string action { get; set; }
        public double openPrice { get; set; }
        public double tp { get; set; }
        public int sl { get; set; }
    }
}