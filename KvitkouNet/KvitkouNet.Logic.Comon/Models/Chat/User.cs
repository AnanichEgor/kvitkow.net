using KvitkouNet.Logic.Common.Models.Chat.Settings;

namespace KvitkouNet.Logic.Common.Models.Chat
{
    public class User
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Роль пользователя в системе
        /// </summary>
        public string Role { get; set; }    // будет тянуться из админки сайта

        /// <summary>
        /// Пользовательские настройки
        /// </summary>
        public UserSettingsChat Settings { get; set; }
    }
}
