namespace KvitkouNet.Logic.Common.Models.UserSettings
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
