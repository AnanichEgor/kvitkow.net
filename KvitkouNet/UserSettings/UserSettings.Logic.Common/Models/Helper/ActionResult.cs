namespace UserSettings.Logic.Common.Models.Helper
{
	/// <summary>
	/// Описание результата
	/// </summary>
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
