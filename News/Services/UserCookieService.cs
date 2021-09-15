namespace News.Services
{
	public class UserCookieService
	{
		private string _userCookieModelJson;
		public string UserCookieModelJson
		{
			get
			{
				return _userCookieModelJson;
			}
			set
			{
				_userCookieModelJson = value;
				NotifyDataChanged();
			}
		}

		public event Action OnChange;
		private void NotifyDataChanged() => OnChange?.Invoke();
	}
}
