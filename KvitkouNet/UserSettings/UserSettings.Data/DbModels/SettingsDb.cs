namespace UserSettings.Data.DbModels
{
	public class SettingsDb
	{
		public int Id { get; set; }

		public string UserId { get; set; }

		public ProfileDb Profile { get; set; }

		public AccountDb Account { get; set; }
	}
}
