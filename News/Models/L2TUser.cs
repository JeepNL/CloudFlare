namespace News.Models
{
	public class L2TUser
	{
		public ulong Id { get; set; }
		public string IdStr { get; set; }
		public string Name { get; set; }
		public string ScreenName { get; set; }
		public string ProfileImageUrlHttps { get; set; }
		public string Location { get; set; }
		public string Description { get; set; }
		public string Url { get; set; }
		public bool Protected { get; set; }
		public string CreatedAt { get; set; }
		public ulong FollowersCount { get; set; }
		public ulong FriendsCount { get; set; }
		public ulong ListedCount { get; set; }
		public ulong StatusesCount { get; set; }
		public ulong FavouritesCount { get; set; }
		public bool Verified { get; set; }
		public bool Suspended { get; set; }
		public string AccessToken { get; set; }
		public string AccessTokenSecret { get; set; }
	}
}
