namespace News.Models
{
	public class CookieModel
	{
		public string Version { get; set; } = string.Empty;
		public string Session { get; set; } = string.Empty;
		public bool Auth { get; set; } = false;
		public string Name { get; set; } = string.Empty;
		public string First { get; set; } = string.Empty;
	}
}
