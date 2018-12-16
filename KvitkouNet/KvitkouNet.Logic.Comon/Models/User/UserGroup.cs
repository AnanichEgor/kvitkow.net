namespace KvitkouNet.Logic.Common.Models.User
{
    public class UserGroup
    {
        /// <summary>
        /// Уникальный номер группы
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя группы
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание назначения группы
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Роль группы
        /// </summary>
        public string GroupRole { get; set; }
    }
}
