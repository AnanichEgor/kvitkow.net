using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Notification.Logic.Models;
using Notification.Logic.Models.Requests;
using Notification.Logic.Services;

namespace Notification.Web.Controllers
{
    [Route("api/notification/email")]
    [ApiController]
    public class EmailNotificationController : ControllerBase
    {
		private IEmailNotificationService m_emailService;
		private IEmailSenderService m_emailSenderService;

		public EmailNotificationController(IEmailNotificationService emailService, IEmailSenderService emailSenderService)
		{
			m_emailService = emailService;
			m_emailSenderService = emailSenderService;
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
			await m_emailService.SendRegistrationNotification(email, senderId, messsage);
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
			return Ok(await m_emailService.GetAllEmailNotifications());
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
			return Ok(await m_emailService.GetEmailNotifications(id));
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
			await m_emailService.SendEmailNotifications(senderId, new UserNotificationBulkRequest
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
			await m_emailService.SendEmailNotifications(senderId, request);
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
			await m_emailService.SendEmailNotificationForAllUsers(senderId, messsage);
			return NoContent();
		}
	}
}