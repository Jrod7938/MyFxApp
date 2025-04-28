namespace MyFxApp.Models {
    public class OpenTradesResponse {
        /// <summary>
        /// Represents the response from the MyFxBook API for open trades.
        /// </summary>
        public bool error { get; set; }
        public string message { get; set; }
        public List<OpenTrade> openTrades { get; set; }
    }
}
