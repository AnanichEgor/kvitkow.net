using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using EasyNetQ.AutoSubscribe;
using Notification.Web.Configs;
using Notification.Logic.Models.Requests;
using Notification.Logic.Services;
using KvitkouNet.Messages.UserManagement;

namespace Notification.Web.Subscriber
{
	public class RegistrationNotificationMessageConsumer : IConsumeAsync<RegistrationMessage>
	{
		private IEmailNotificationService m_service;
		private IConfiguration m_config;

		public RegistrationNotificationMessageConsumer(IEmailNotificationService service, IConfiguration config)
		{
			m_service = service;
			m_config = config;
		}

		[AutoSubscriberConsumer(SubscriptionId = "RegistrationMessage")]
		public async Task ConsumeAsync(RegistrationMessage message)
		{
			SenderConfig senderConfig = m_config.GetSection("SenderConfig").Get<SenderConfig>();
			SendEmailRequest request = new SendEmailRequest
			{
				ReceiverEmail = message.Name,
				ReceiverName = message.Email,
				Subject = "Подтверждение регистрации",
				Text = $"Для подтверждения регистрации прейдите по ссылке {m_config[$"RegistrationUrl?userName={message.Name}"]}",
				SenderName = senderConfig.Name,
				SenderEmail = senderConfig.Email,
				SenderPassword = senderConfig.Password
			};

			await m_service.SendRegistrationNotification(request);
		}
	}
}
