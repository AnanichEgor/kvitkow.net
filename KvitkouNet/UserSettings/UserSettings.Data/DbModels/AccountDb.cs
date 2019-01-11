namespace UserSettings.Data.DbModels
{
	public class AccountDb
	{
		/// <summary>
		/// Ключ
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Пароль пользователя.
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// Почта пользователя.
		/// </summary>
		public string Email { get; set; }
	}
}
