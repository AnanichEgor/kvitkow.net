namespace UserSettings.Logic.Models
{
	/// <summary>
	/// Обновление аккаунта
	/// </summary>
	public class Account
	{
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
