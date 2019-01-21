using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NSwag.Annotations;
using Notification.Logic.Models;
using Notification.Logic.Models.Requests;
using Notification.Logic.Services;
using Notification.Web.Configs;

namespace Notification.Web.Controllers
{
    [Route("api/notification/email")]
    [ApiController]
    public class EmailNotificationController : ControllerBase
    {
		private IEmailNotificationService m_emailService;
		private IConfiguration m_config;

		public EmailNotificationController(IEmailNotificationService emailService, IConfiguration config)
		{
			m_emailService = emailService;
			m_config = config;
		}

		/// <summary>
		/// Отправляет сообщение для подтверждения регистрации
		/// </summary>
		/// <param name="userName">Имя пользователя</param>
		/// <param name="email">Почта пользователя</param>
		/// <param name="url">Ссылка на подтверждение</param>
		[HttpPost, Route("registration")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(NoContentResult))]
		public async Task<IActionResult> SendRegistrationNotification([FromQuery] string userName, [FromQuery] string email, [FromBody] string url)
		{
			SenderConfig senderConfig = m_config.GetSection("SenderConfig").Get<SenderConfig>();
			SendEmailRequest request = new SendEmailRequest
			{
				ReceiverEmail = email,
				ReceiverName = userName,
				Subject = "Подтверждение регистрации",
				Text = $"Для подтверждения регистрации прейдите по ссылке {url}",
				SenderName = senderConfig.Name,
				SenderEmail = senderConfig.Email,
				SenderPassword = senderConfig.Password				
			};

			await m_emailService.SendRegistrationNotification(request);

			return NoContent();
		}

		/// <summary>
		/// Получить все email уведомления
		/// </summary>
		/// <returns>Список email уведомлений</returns>
		[HttpGet, Route("all")]
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
		[HttpGet, Route("users/{id}")]
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
		[HttpPost, Route("users/{id}")]
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
		[HttpPost, Route("users/ids")]
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
		[HttpPost, Route("users")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(NoContentResult))]
		public async Task<IActionResult> SendEmailNotificationForAllUsers([FromQuery] string senderId, [FromBody] NotificationMessage messsage)
		{
			await m_emailService.SendEmailNotificationForAllUsers(senderId, messsage);
			return NoContent();
		}
	}
}