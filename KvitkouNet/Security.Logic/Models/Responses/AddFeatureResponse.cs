namespace Security.Logic.Models.Responses
{
    /// <summary>
    /// Результат добавления фичи
    /// </summary>
    public class AddFeatureResponse : ActionResponse
    {
        /// <summary>
        /// Идентификатор фичи
        /// </summary>
        public int Id { get; set; }
    }
}
