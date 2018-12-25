using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KvitkouNet.Web.Models
{
	/// <summary>
	/// Дополнительные настройки
	/// </summary>
	public class ExtraInfoDto
	{
		/// <summary>
		/// Флаг, отвечающий за закрытость аккаунта для гостей.
		/// </summary>
		public bool IsPrivateAccount { get; set; }

		/// <summary>
		/// Предпочитаемый адрес доступных билетов.
		/// </summary>
		public string PreferAddress { get; set; }

		/// <summary>
		/// Предпочитаемый район доступных билетов.
		/// </summary>
		public string PreferRegion { get; set; }

		/// <summary>
		/// Флаг, отвечающий за получение информации о билетах.
		/// </summary>
		public bool IsGetTicketInfo { get; set; }

		/// <summary>
		/// Ссылки на социальные сети.
		/// </summary>
		public IEnumerable<object> SocialNetwork { get; set; }

		/// <summary>
		/// Предпочитаемое место посещения
		/// </summary>
		public string PreferPlace { get; set; }
	}
}
