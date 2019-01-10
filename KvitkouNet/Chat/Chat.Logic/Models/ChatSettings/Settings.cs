using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Logic.Models.ChatSettings
{
    public class Settings
    {
        /// <summary>
        /// Уникальный UserId.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Роль пользователя в комнате.
        ///  </summary>
        public string Role { get; set; }

        /// <summary>
        /// Фон чата
        /// </summary>
        public BackgroundColor BackgroundColor { get; set; }

        /// <summary>
        /// Звуковое уведомление. false - выкл. default - true.
        /// </summary>
        public bool Sound { get; set; }

        /// <summary>
        /// Всплывающие уведомление. false - выключено. default - true.
        /// </summary>
        public bool Toast { get; set; }

        /// <summary>
        /// Открыть чат в новой вкладке или в основной. default - false - В основной.
        /// </summary>
        public bool Tab { get; set; }

        /// <summary>
        /// Отображать ли время сообщения. default - false - Не отображать время сообщения.
        /// </summary>
        public bool ViewTimestampsMessage { get; set; }

        /// <summary>
        /// Скрытость чата. default - false - Не скрывать чат.
        /// </summary>
        public bool HideChat { get; set; }

        /// <summary>
        /// Настройка отображения колличества сообщений из истории чата. default - 100 сообщений
        /// </summary>
        public int HistoryCountsMessages { get; set; }
    }
}

