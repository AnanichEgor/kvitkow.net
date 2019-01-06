using Logging.Logic.Common.Enums;
using Logging.Logic.Common.Models.Abstraction;
using Logging.Logic.Common.Models.UserManagement;

namespace Logging.Logic.Common.Models
{
	/// <summary>
	/// Запись в лог, описывающая действие с аккаунтом пользователя
	/// </summary>
	public class AccountLogEntry : BaseLogEntry<long>
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
