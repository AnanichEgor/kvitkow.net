using KvitkouNet.Logic.Common.Models.Security.Enums;

namespace KvitkouNet.Logic.Common.Models.Security.Responses
{
    /// <summary>
    /// Результат выполнения операции
    /// </summary>
    public class ActionResponse
    {
        /// <summary>
        /// Статус выполнения операции
        /// </summary>
        public ActionStatus Status { get; set; }

        /// <summary>
        /// Дополнительная информация о выполнении
        /// </summary>
        public string Message { get; set; }
    }
}
