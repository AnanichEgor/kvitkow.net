using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Notification.Data.Context;
using Notification.Logic.Models;
using Notification.Logic.Models.Requests;

namespace Notification.Logic.Services
{
	public class NotificationService : INotificationService
	{
		private NotificationContext m_context;
		private IMapper m_mapper;

		public NotificationService(NotificationContext context, IMapper mapper)
		{
			m_context = context;
			m_mapper = mapper;
		}

		public Task AddUserNotifications(UserNotificationBulkRequest request)
		{			
			throw new NotImplementedException();
		}

		public Task EditNotification(UserNotification userNotification)
		{
			throw new NotImplementedException();
		}

		// проверочный метод
		public Task<IEnumerable<UserNotification>> GetAll()
		{
			var result = m_context.Notifications.AsNoTracking()
				.Include(x => x.User).ToArray();

			var mapped = m_mapper.Map<UserNotification[]>(result);

			return Task.FromResult(mapped.AsEnumerable());
		}

		public Task<IEnumerable<EmailNotification>> GetAllEmailNotifications()
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<EmailNotification>> GetEmailNotifications(string userId)
		{
			throw new NotImplementedException();
		}

		public Task<UserNotification> GetNotification(string notificationId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<UserNotification>> GetUserNotifications(string userId, bool onlyOpen)
		{
			throw new NotImplementedException();
		}

		public Task SendEmailNotificationForAllUsers(string senderId, NotificationMessage messsage)
		{
			throw new NotImplementedException();
		}

		public Task SendEmailNotifications(string senderId, UserNotificationBulkRequest request)
		{
			throw new NotImplementedException();
		}

		public Task SendRegistrationNotification(string email, string senderId, NotificationMessage messsage)
		{
			throw new NotImplementedException();
		}

		public Task SetStatusClosed(string notificationId)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			m_context.Dispose();
		}
	}
}
