
namespace Dashboard.Logic.Models.Enums
{
    /// <summary>
    ///     Перечисление, описывающее статус новости
    /// </summary>
    public enum NewsStatus
    {
        /// <summary>
        ///     Тип не установлен
        /// </summary>
        Unknown = 0,

        /// <summary>
        ///     Актуальна
        /// </summary>
        Actual = 1,

        /// <summary>
        ///     Просрочена
        /// </summary>
        Expired = 2
    }
}
