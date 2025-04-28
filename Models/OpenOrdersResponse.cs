namespace MyFxApp.Models {
    public class OpenOrdersResponse {
        /// <summary>
        /// Represents the response from the MyFxBook API for open orders.
        /// </summary>
        public bool error { get; set; }
        public string message { get; set; }
        public List<OpenOrder> openOrders { get; set; }
    }
}
