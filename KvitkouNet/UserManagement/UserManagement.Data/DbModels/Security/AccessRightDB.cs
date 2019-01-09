
namespace UserManagement.Data.DbModels.Security
{
    /// <summary>
    /// Право доступа
    /// </summary>
    public class AccessRightDB
    {
        /// <summary>
        /// Идентификатор права доступа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя права доступа
        /// </summary>
        public string Name { get; set; }
    }
}
