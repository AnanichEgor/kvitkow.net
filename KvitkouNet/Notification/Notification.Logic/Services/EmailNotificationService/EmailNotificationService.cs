using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Notification.Data.Context;
using Notification.Data.Models;
using Notification.Logic.Models;
using Notification.Logic.Models.Requests;

namespace Notification.Logic.Services.EmailNotificationService
{
	class EmailNotificationService : IEmailNotificationService
	{
		private NotificationContext m_context;
		private IMapper m_mapper;
		private IEmailSenderService m_emailSenderService;

		public EmailNotificationService(NotificationContext context, IEmailSenderService emailSenderService, IMapper mapper)
		{
			m_context = context;
			m_emailSenderService = emailSenderService;
			m_mapper = mapper;
		}

		public async Task<IEnumerable<EmailNotification>> GetAllEmailNotifications()
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<EmailNotification>> GetEmailNotifications(string userId)
		{
			throw new NotImplementedException();
		}

		public async Task SendEmailNotificationForAllUsers(string senderId, NotificationMessage messsage)
		{
			throw new NotImplementedException();
		}

		public async Task SendEmailNotifications(string senderId, UserNotificationBulkRequest request)
		{
			throw new NotImplementedException();
		}

		public async Task SendRegistrationNotification(SendEmailRequest sendEmailRequest)
		{
			await m_emailSenderService.SendEmailAsync(sendEmailRequest);

			m_context.SaveChanges();
		}

		public void Dispose()
		{
			m_context.Dispose();
		}	
	}
}
