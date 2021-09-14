namespace News.Models
{
	public class UserCookieModel
	{
		public string Version { get; set; } = string.Empty;
		public string Session { get; set; } = string.Empty;
		public bool Authenticated { get; set; } = false;
		public string Theme { get; set; } = "light";
	}
}
