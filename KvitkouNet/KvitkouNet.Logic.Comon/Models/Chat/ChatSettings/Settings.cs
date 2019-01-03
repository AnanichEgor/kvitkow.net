﻿
using KvitkouNet.Logic.Common.Models.Security;

namespace KvitkouNet.Logic.Common.Models.Chat.ChatSettings
{
    public class Settings
    {
        /// <summary>
        /// Уникальный UserId
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Роль пользователя в комнате
        ///  </summary>
        public string Role { get; set; }

        /// <summary>
        /// Фон чата
        /// </summary>
        public BackgroundColor BackgroundColor { get; set; }

        /// <summary>
        /// Звуковое уведомление
        /// </summary>
        public Sound Sound { get; set; }

        /// <summary>
        /// Всплывающие уведомление
        /// </summary>
        public Toast Toast { get; set; }

        /// <summary>
        /// Открыть чат в новой вкладке или в основной
        /// </summary>
        public Tab Tab { get; set; }

        /// <summary>
        /// Отображать ли время сообщения
        /// </summary>
        public ViewTimestampsMessage ViewTimestampsMessage { get; set; }

        /// <summary>
        /// Скрыть чат
        /// </summary>
        public HideChat HideChat { get; set; }

        /// <summary>
        /// настройка отображения колличества сообщений из истории чата
        /// </summary>
        public int HistoryCountsMessages { get; set; }
    }
}
