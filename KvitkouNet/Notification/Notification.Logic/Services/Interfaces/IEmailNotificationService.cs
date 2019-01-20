using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Notification.Logic.Models;
using Notification.Logic.Models.Requests;

namespace Notification.Logic.Services
{
	/// <summary>
	/// Интерфейс для почтовых уведомлений пользователя
	/// </summary>
	public interface IEmailNotificationService : IDisposable
	{
		/// <summary>
		/// Получить все email уведомления
		/// </summary>
		/// <returns>Список email уведомлений</returns>
		Task<IEnumerable<EmailNotification>> GetAllEmailNotifications();

		/// <summary>
		/// Получить email уведомления для пользователя
		/// </summary>
		/// <param name="userId">ИД пользователя</param>
		/// <returns>Список email уведомлений</returns>
		Task<IEnumerable<EmailNotification>> GetEmailNotifications(string userId);

		/// <summary>
		/// Отправляет сообщение для подтверждения регистрации
		/// </summary>
		/// <param name="senderId">ИД пользователя, отправляющего соообщение</param>
		/// <param name="email">Ящик почты</param>
		/// <param name="notification">Уведомление</param>
		/// <returns></returns>
		Task SendRegistrationNotification(string email, string senderId, NotificationMessage messsage);

		/// <summary>
		/// Отправить email уведомление для пользователей
		/// </summary>
		/// <param name="senderId">ИД пользователя, отправляющего соообщение</param>
		/// <param name="request">Массовая отправка сообщений пользователям</param>
		/// <returns></returns>
		Task SendEmailNotifications(string senderId, UserNotificationBulkRequest request);

		/// <summary>
		/// Отправить email уведомление всем пользователям
		/// </summary>
		/// <param name="senderId">ИД пользователя, отправляющего соообщение</param>
		/// <param name="messsage">Сообщение уведомления</param>
		/// <returns></returns>
		Task SendEmailNotificationForAllUsers(string senderId, NotificationMessage messsage);
	}
}
