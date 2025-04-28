namespace MyFxApp.Models {
    /// <summary>
    /// Represents the response from the MyFxBook API for daily data.
    /// </summary>
    public class DataDailyResponse {
        public bool error { get; set; }
        public string message { get; set; }
        public List<List<DataDaily>> dataDaily { get; set; }
    }
}
