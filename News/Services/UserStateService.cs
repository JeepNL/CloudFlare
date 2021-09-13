namespace News.Services
{
	public class UserStateService
	{
		// auth 0, name 1, first 2, id  3, screen 4
		private Array _userStateArray = Array.CreateInstance(typeof(String), 5);
		public Array UserStateArray { get { return _userStateArray; } set { _userStateArray = value; NotifyDataChanged(); } }

		public event Action OnChange;
		private void NotifyDataChanged() => OnChange?.Invoke();
	}
}
