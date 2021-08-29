namespace News.Models
{
	public class UserModel
	{
		public bool IsAuthenticated { get; set; } = false;
		public string Email { get; set; } = string.Empty;
	}
}
