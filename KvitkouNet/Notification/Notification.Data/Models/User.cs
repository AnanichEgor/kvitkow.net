namespace Notification.Data.Models
{
	/// <summary>
	/// Пользователь
	/// </summary>
	public class User
	{
		/// <summary>
		/// Ид пользователя
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Электронный ящик
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Имя пользователя
		/// </summary>
		public string FirstName { get; set; }
	}
}
