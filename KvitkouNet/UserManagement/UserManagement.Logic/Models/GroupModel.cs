
namespace UserManagement.Logic.Models
{
    public class GroupModel
    {
        /// <summary>
        /// Уникальный номер группы
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Имя группы
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание назначения группы
        /// </summary>
        public string Description { get; set; }
    }
}