using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Notification.Data.Context;
using Notification.Logic.Models;
using Notification.Logic.Models.Requests;

namespace Notification.Logic.Services.NotificationService
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

		public async Task AddUserNotifications(UserNotificationBulkRequest request)
		{			
			throw new NotImplementedException();
		}

		public async Task EditNotification(UserNotification userNotification)
		{
			throw new NotImplementedException();
		}

		// проверочный метод
		public async Task<IEnumerable<UserNotification>> GetAll()
		{
			var result = m_context.Notifications.AsNoTracking()
				.Include(x => x.User).ToArray();

			var mapped = m_mapper.Map<UserNotification[]>(result);

			return await Task.FromResult(mapped.AsEnumerable());
		}

		public async Task<UserNotification> GetNotification(string notificationId)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<UserNotification>> GetUserNotifications(string userId, bool onlyOpen)
		{
			throw new NotImplementedException();
		}

		public async Task SetStatusClosed(string notificationId)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			m_context.Dispose();
		}
	}
}
