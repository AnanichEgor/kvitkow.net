using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSwag.Annotations;
using System.Net;
using KvitkouNet.Logic.Common.Models.Notification;
using KvitkouNet.Web.Models.Notification;
using System.Collections.ObjectModel;

namespace KvitkouNet.Web.Controllers
{
	/// <summary>
	/// api для уведомлений
	/// </summary>
	[Route("api/notification")]
	public class NotificationController : Controller
	{
		/// <summary>
		/// Получить все уведомления
		/// </summary>
		/// <remarks>email уведомления не входят</remarks>
		/// <returns>возвращает список уведомлений для пользователя</returns>
		[HttpGet, Route("all")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<UserNotification>), Description = "All OK")]
		public async Task<IActionResult> GetAll()
		{
			IEnumerable<UserNotification> result = await Task.FromResult(new Collection<UserNotification>());
			return Ok(result);
		}

		/// <summary>
		/// Получить уведомление
		/// </summary>
		/// <param name="notificationId">ИД уведомления</param>
		/// <returns>возвращает список уведомлений для пользователяй</returns>
		[HttpGet, Route("id")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<UserNotification>))]
		[SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Notification not found")]
		public async Task<IActionResult> GetNotification([FromBody] string notificationId)
		{
			IEnumerable<UserNotification> result = await Task.FromResult(new Collection<UserNotification>());
			return Ok(result);
		}

		/// <summary>
		/// Обновить уведомление
		/// </summary>
		/// <param name="notificationId">ИД уведомления</param>
		/// <param name="notification">параметры уведомления</param>
		/// <remarks>email уведомления не обновляются</remarks>
		[HttpPatch, Route("id")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(NoContentResult))]
		[SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "Notification not found")]
		public async Task<IActionResult> EditNotification(string notificationId, [FromBody] NotificationModel notification)
		{
			string result = await Task.FromResult("");
			return NoContent();
		}

		/// <summary>
		/// Получить уведомления для пользователя
		/// </summary>
		/// <param name="userId">ИД пользователя</param>
		/// <param name="onlyOpen">только незакрытые уведомления</param>
		/// <returns>возвращает список уведомлений для пользователя</returns>
		[HttpGet, Route("users/id")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<UserNotification>), Description = "All OK")]
		[SwaggerResponse(HttpStatusCode.Forbidden, typeof(void), Description = "User not found")]
		public async Task<IActionResult> GetUserNotification(string userId, bool onlyOpen = true)
		{
			IEnumerable<UserNotification> result = await Task.FromResult(new Collection<UserNotification>());
			return Ok(result);
		}

		/// <summary>
		/// Создать уведомление для пользователя
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="notification"></param>
		[HttpPost, Route("users/id")]
		[SwaggerResponse(HttpStatusCode.Created, typeof(CreatedResult))]
		public async Task<IActionResult> AddUserNotification(string userId, [FromBody] NotificationModel notification)
		{
			UserNotification result = await Task.FromResult(new UserNotification());
			return Created("api/notification/users/id/" + 1, result);
		}

		/// <summary>
		/// Отметить как прочитанное уведомление для пользователя
		/// </summary>
		[HttpDelete, Route("users/id")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(NoContentResult))]
		public async Task<IActionResult> SetStatusClosed([FromBody] string notificationId)
		{
			string result = await Task.FromResult("");
			return NoContent();
		}

		/// <summary>
		/// Создать уведомления для пользователей
		/// </summary>
		/// <param name="userIds"></param>
		/// <param name="notification"></param>
		/// <remarks>Для ненайденных пользователей уведомление не будет создано</remarks>
		[HttpPost, Route("users/ids")]
		[SwaggerResponse(HttpStatusCode.NoContent, typeof(NoContentResult))]
		public async Task<IActionResult> AddNotificationForUsers([FromBody] NotificationBulkModel notification)
		{
			string result = await Task.FromResult("");
			return NoContent();
		}

		/// <summary>
		/// Отправляет сообщение для подтверждения регистрации
		/// </summary>
		/// <param name="senderId">ИД пользователя, отправляющего соообщение</param>
		/// <param name="email">Ящик почты</param>
		/// <param name="notification">Уведомление</param>
		[HttpPost, Route("registration")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(NoContentResult))]
		public async Task<IActionResult> SendRegistrationNotification(string senderId, string email, [FromBody] NotificationModel notification)
		{
			Task<bool> result = Task.FromResult(true);
			return Ok(await result);
		}

		/// <summary>
		/// Получить все email уведомления
		/// </summary>
		/// <returns>Список email уведомлений</returns>
		[HttpGet, Route("all/email")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<EmailNotification>))]
		public async Task<IActionResult> GetAllEmailNotification()
		{
			IEnumerable<EmailNotification> result = await Task.FromResult(new Collection<EmailNotification>());
			return Ok(result);
		}

		/// <summary>
		/// Получить email уведомления для пользователя
		/// </summary>
		/// <param name="userId">ИД пользователя</param>
		/// <returns>Список email уведомлений</returns>
		[HttpGet, Route("users/id/email")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<EmailNotification>), Description = "All OK")]
		public async Task<IActionResult> GetEmailNotification([FromBody] string userId)
		{
			IEnumerable<EmailNotification> result = await Task.FromResult(new Collection<EmailNotification>());
			return Ok(result);
		}

		/// <summary>
		/// Отправить email уведомление для пользователя
		/// </summary>
		/// <param name="userId">ИД пользователя</param>
		/// <param name="senderId">ИД пользователя, отправляющего соообщение</param>
		/// <param name="notification">Уведомление</param>
		[HttpPost, Route("users/id/email")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(NoContentResult))]
		public async Task<IActionResult> SendEmailNotification(string userId, string senderId, [FromBody] NotificationModel notification)
		{
			string result = await Task.FromResult("");
			return NoContent();
		}

		/// <summary>
		/// Отправить email уведомление для пользователей
		/// </summary>
		/// <param name="senderId">ИД пользователя, отправляющего соообщение</param>
		/// <param name="notification">Уведомление</param>
		[HttpPost, Route("users/ids/email")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(NoContentResult))]
		public async Task<IActionResult> SendEmailNotificationForUsers(string senderId, [FromBody] NotificationBulkModel notification)
		{
			string result = await Task.FromResult("");
			return NoContent();
		}

		/// <summary>
		/// Отправить email уведомление всем пользователям
		/// </summary>
		/// <param name="senderId">ИД пользователя, отправляющего соообщение</param>
		/// <param name="notification">Уведомление</param>
		[HttpPost, Route("users/email")]
		[SwaggerResponse(HttpStatusCode.OK, typeof(NoContentResult))]
		public async Task<IActionResult> SendEmailNotificationForAllUsers(string senderId, [FromBody] NotificationModel notification)
		{
			string result = await Task.FromResult("");
			return NoContent();
		}
	}
}