namespace KvitkouNet.Web.Models
{
	public class UserAccountModel
	{
		/// <summary>
		/// Текущий пароль пользователя.
		/// </summary>
		public string OldPassword { get; set; }

		/// <summary>
		/// Новый пароль.
		/// </summary>
		public string NewPassword { get; set; }

		/// <summary>
		/// Подтверждение нового пароля.
		/// </summary>
		public string ConfirmPassword { get; set; }

		/// <summary>
		/// Почта пользователя.
		/// </summary>
		public string Email { get; set; }
	}
}
