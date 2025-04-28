namespace MyFxApp.Models {
    public class LoginResponse {
        /// <summary>
        /// Represents the response from the MyFxBook API for login.
        /// </summary>
        public bool error { get; set; }
        public string message { get; set; }
        public string session { get; set; }
    }
}