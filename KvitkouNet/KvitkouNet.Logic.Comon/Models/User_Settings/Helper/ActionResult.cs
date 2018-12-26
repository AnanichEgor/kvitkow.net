using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Logic.Common.Models.User_Settings
{
	public class ActionResult
	{
		/// <summary>
		/// Результат.
		/// </summary>
		public ResultEnum UpdateResult { get; set; }

		/// <summary>
		/// Дополнительная информация.
		/// </summary>
		public string Message { get; set; }
	}
}
