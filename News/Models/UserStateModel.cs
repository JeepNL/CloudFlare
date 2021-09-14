namespace News.Models
{
    public class UserStateModel
    {
        public bool Authenticated { get; set; } = false;
        public string Session { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string IpAddress { get; set; } = string.Empty;
        public string ScreenRes { get; set; } = string.Empty;
    }
}
