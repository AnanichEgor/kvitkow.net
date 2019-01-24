namespace Security.Logic.Models.Responses
{
    /// <summary>
    /// Результат добавления фичи
    /// </summary>
    public class FeatureResponse : ActionResponse
    {
        /// <summary>
        /// Идентификатор фичи
        /// </summary>
        public Feature[] Features { get; set; }
    }
}
