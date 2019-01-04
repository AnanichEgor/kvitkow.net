using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KvitkouNet.Logic.Common.Models.Notification;
using KvitkouNet.Logic.Common.Models.Notification.Requests;

namespace KvitkouNet.Logic.Common.Services.Notification
{
	/// <summary>
	/// Интерфейс для работы с уведомлениями
	/// </summary>
	public interface INotificationService : IDisposable
	{
		/// <summary>
		/// Получить все уведомления
		/// </summary>
		/// <returns>возвращает список уведомлений для пользователя</returns>
		/// <remarks>email уведомления не входят</remarks>
		Task<IEnumerable<UserNotification>> GetAll();

		/// <summary>
		/// Получить уведомление
		/// </summary>
		/// <param name="notificationId">ИД уведомления</param>
		/// <returns>возвращает уведомление для пользователя</returns>
		Task<UserNotification> GetNotification(string notificationId);

		/// <summary>
		/// Обновить уведомление
		/// </summary>
		/// <param name="userNotification">параметры уведомления</param>
		/// <remarks>email уведомления не обновляются</remarks>
		Task EditNotification(UserNotification userNotification);

		/// <summary>
		/// Получить уведомления для пользователя
		/// </summary>
		/// <param name="userId">ИД пользователя</param>
		/// <param name="onlyOpen">Признак действующий уведомлений</param>
		/// <returns>возвращает список уведомлений для пользователя</returns>
		Task<IEnumerable<UserNotification>> GetUserNotifications(string userId, bool onlyOpen);

		/// <summary>
		/// Создать уведомление для пользователей
		/// </summary>
		/// <param name="request">Запрос для уведомления</param>
		/// <remarks>Для ненайденных пользователей уведомление не будет создано</remarks>
		Task AddUserNotifications(UserNotificationBulkRequest request);

		/// <summary>
		/// Отметить как прочитанное уведомление для пользователя
		/// </summary>
		/// <param name="notificationId">ИД уведомления</param>
		Task SetStatusClosed(string notificationId);

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