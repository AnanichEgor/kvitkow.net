namespace KvitkouNet.Logic.Common.Models.Security.Responses
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
