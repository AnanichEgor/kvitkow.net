namespace Security.Logic.Models.Responses
{
    /// <summary>
    /// Результат добавления функции
    /// </summary>
    public class AccessFunctionResponse : ActionResponse
    {
        /// <summary>
        /// Идентификатор функции
        /// </summary>
        public AccessFunction[] AccessFunctions { get; set; }
    }
}
