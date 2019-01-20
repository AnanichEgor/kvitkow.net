using Logging.Data.Enums;
using Logging.Logic.Models.Abstraction;
using Logging.Logic.Models.UserManagement;

namespace Logging.Logic.Models
{
	/// <summary>
	/// Запись в лог, описывающая действие с аккаунтом пользователя
	/// </summary>
	public class AccountLogEntry : BaseLogEntry
	{
		/// <summary>
		/// Пользователь
		/// </summary>
		public User User { get; set; }

		/// <summary>
		/// Тип действия
		/// </summary>
		public AccountActionType Type { get; set; }

		/// <summary>
		/// Описание пользовательского устройства
		/// </summary>
		public string DeviceDescription { get; set; }
	}
}
