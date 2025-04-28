namespace MyFxApp.Models {
    public class HistoryResponse {
        /// <summary>
        /// Represents the response from the MyFxBook API for trade history.
        /// </summary>
        public bool error { get; set; }
        public string message { get; set; }
        public List<HistoryEntry> history { get; set; }
    }
}
