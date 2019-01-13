using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Notification.Logic.Models;
using Notification.Logic.Services;
using Notification.Logic.Models.Requests;

namespace Notification.Web.Controllers
{
	/// <summary>
	/// api для уведомлений
	/// </summary>
	[Route("api/notification")]
	public class NotificationController : Controller
	{
		private INotificationService m_service;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="service"></param>
		public NotificationController(INotificationService service)
		{
			m_service = service;
		}

		/// <summary>
		/// Получить все уведомления
		/// </summary>
		/// <returns>возвращает список уведомлений для пользователя</returns>
		/// <remarks>email уведомления не входят</remarks>
		[HttpGet, Route("all")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<UserNotification>), Description = "All OK")]
		public async Task<IActionResult> GetAll()
		{
			
			return Ok(await m_service.GetAll());
		}

		/// <summary>
		/// Получить уведомление
		/// </summary>
		/// <param name="id">ИД уведомления</param>
		/// <returns>возвращает уведомление для пользователя</returns>
		[HttpGet, Route("{id}")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(UserNotification))]
		[SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Notification not found")]
		public async Task<IActionResult> GetNotification([FromRoute] string id)
		{
			return Ok(await m_service.GetNotification(id));
		}

		/// <summary>
		/// Обновить уведомление
		/// </summary>
		/// <param name="id">ИД уведомления</param>
		/// <param name="messsage">Сообщение уведомления</param>
		/// <remarks>email уведомления не обновляются</remarks>
		[HttpPatch, Route("{id}")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(NoContentResult))]
		[SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Notification not found")]
		public async Task<IActionResult> EditNotification([FromRoute] string id, [FromBody] NotificationMessage messsage)
		{
			await m_service.EditNotification(new UserNotification
			{
				NotificationId = id,
				Message = messsage
			});

			return NoContent();
		}

		/// <summary>
		/// Получить уведомления для пользователя
		/// </summary>
		/// <param name="id">ИД пользователя</param>
		/// <param name="onlyOpen">только незакрытые уведомления</param>
		/// <returns>возвращает список уведомлений для пользователя</returns>
		[HttpGet, Route("users/{id}")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<UserNotification>), Description = "All OK")]
		[SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "User not found")]
		public async Task<IActionResult> GetUserNotifications([FromRoute] string id, [FromQuery] bool onlyOpen = true)
		{			
			return Ok(await m_service.GetUserNotifications(id, onlyOpen));
		}

		/// <summary>
		/// Создать уведомление для пользователя
		/// </summary>
		/// <param name="id">ИД пользователя</param>
		/// <param name="messsage">Сообщение уведомления</param>
		[HttpPost, Route("users/{id}")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(NoContentResult))]
		public async Task<IActionResult> AddUserNotification([FromRoute] string id, [FromBody] NotificationMessage messsage)
		{
			await m_service.AddUserNotifications(new UserNotificationBulkRequest
			{
				UserIds = new string[] { id },
				Message = messsage
			});
			return NoContent();
		}

		/// <summary>
		/// Отметить как прочитанное уведомление для пользователя
		/// </summary>
		[HttpDelete, Route("users/{id}")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(NoContentResult))]
		public async Task<IActionResult> SetStatusClosed([FromRoute] string id)
		{
			await m_service.SetStatusClosed(id);
			return NoContent();
		}

		/// <summary>
		/// Создать уведомления для пользователей
		/// </summary>
		/// <param name="request">Массовый запрос для пользователей</param>
		/// <remarks>Для ненайденных пользователей уведомление не будет создано</remarks>
		[HttpPost, Route("users/ids")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(NoContentResult))]
		public async Task<IActionResult> AddNotifications([FromBody] UserNotificationBulkRequest request)
		{
			await m_service.AddUserNotifications(request);
			return NoContent();
		}

		/// <summary>
		/// Отправляет сообщение для подтверждения регистрации
		/// </summary>
		/// <param name="email">Ящик почты</param>
		/// <param name="senderId">ИД пользователя, отправляющего соообщение</param>
		/// <param name="messsage">Сообщение уведомления</param>
		[HttpPost, Route("registration/{email}")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(NoContentResult))]
		public async Task<IActionResult> SendRegistrationNotification([FromRoute] string email, [FromQuery] string senderId, [FromBody] NotificationMessage messsage)
		{
			await m_service.SendRegistrationNotification(email, senderId, messsage);
			return NoContent();
		}

		/// <summary>
		/// Получить все email уведомления
		/// </summary>
		/// <returns>Список email уведомлений</returns>
		[HttpGet, Route("all/email")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<EmailNotification>))]
		public async Task<IActionResult> GetAllEmailNotifications()
		{
			return Ok(await m_service.GetAllEmailNotifications());
		}

		/// <summary>
		/// Получить email уведомления для пользователя
		/// </summary>
		/// <param name="id">ИД пользователя</param>
		/// <returns>Список email уведомлений</returns>
		[HttpGet, Route("users/{id}/email")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<EmailNotification>), Description = "All OK")]
		public async Task<IActionResult> GetEmailNotifications([FromRoute] string id)
		{
			return Ok(await m_service.GetEmailNotifications(id));
		}

		/// <summary>
		/// Отправить email уведомление для пользователя
		/// </summary>
		/// <param name="id">ИД пользователя</param>
		/// <param name="senderId">ИД пользователя, отправляющего соообщение</param>
		/// <param name="messsage">Сообщение уведомления</param>
		[HttpPost, Route("users/{id}/email")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(NoContentResult))]
		public async Task<IActionResult> SendEmailNotification([FromRoute] string id, [FromQuery] string senderId, [FromBody] NotificationMessage messsage)
		{
			await m_service.SendEmailNotifications(senderId, new UserNotificationBulkRequest
			{
				UserIds = new string[] { id },
				Message = messsage
			});
			return NoContent();
		}

		/// <summary>
		/// Отправить email уведомление для пользователей
		/// </summary>
		/// <param name="senderId">ИД пользователя, отправляющего соообщение</param>
		/// <param name="request">Массовый запрос для пользователей</param>
		[HttpPost, Route("users/ids/email")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(NoContentResult))]
		public async Task<IActionResult> SendEmailNotifications([FromQuery] string senderId, [FromBody] UserNotificationBulkRequest request)
		{
			await m_service.SendEmailNotifications(senderId, request);
			return NoContent();
		}

		/// <summary>
		/// Отправить email уведомление всем пользователям
		/// </summary>
		/// <param name="senderId">ИД пользователя, отправляющего соообщение</param>
		/// <param name="messsage">Сообщение уведомления</param>
		[HttpPost, Route("users/email")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(NoContentResult))]
		public async Task<IActionResult> SendEmailNotificationForAllUsers([FromQuery] string senderId, [FromBody] NotificationMessage messsage)
		{
			await m_service.SendEmailNotificationForAllUsers(senderId, messsage);
			return NoContent();
		}
	}
}