namespace UserSettings.Data.DbModels
{
	public class SettingsDb
	{
		public int Id { get; set; }

		/// <summary>
		/// Id пользователя
		/// </summary>
		public string UserId { get; set; }

		/// <summary>
		/// Настройки пользователя пользователя
		/// </summary>
		public ProfileDb Profile { get; set; }

		/// <summary>
		/// Настройски аккаунта пользователя
		/// </summary>
		public AccountDb Account { get; set; }
	}
}
