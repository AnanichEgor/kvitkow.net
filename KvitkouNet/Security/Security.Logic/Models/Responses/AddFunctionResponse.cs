namespace Security.Logic.Models.Responses
{
    /// <summary>
    /// Результат добавления функции
    /// </summary>
    public class AddFunctionResponse : ActionResponse
    {
        /// <summary>
        /// Идентификатор функции
        /// </summary>
        public int Id { get; set; }
    }
}
