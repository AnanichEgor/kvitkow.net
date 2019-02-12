using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Notification.Data.Context;
using Notification.Logic.Models;
using Notification.Logic.Models.Requests;
using Notification.Data.Models;
using Notification.Data.Models.Enums;

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
			IQueryable<User> users = m_context.Users.Where(x => request.UserIds.Any(id => id == x.Id));
			Data.Models.Notification notification = m_mapper.Map<NotificationMessage, Data.Models.Notification>(request.Message);
			DateTime date = DateTime.UtcNow;          
            foreach (User user in users)
			{
                Data.Models.Notification notification2 = new Data.Models.Notification
                {
                    User = user,
                    Date = date,
                    IsClosed = false,
                    Type = NotificationType.Notification,
                    Text = notification.Text,
                    Title = notification.Title,
                    Severity = notification.Severity
                };
                m_context.Notifications.Add(notification2);
			}
            try
            {
                await m_context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
			
		}

		public async Task EditNotification(UserNotification userNotification)
		{
			Data.Models.Notification oldNotification = await m_context.Notifications.SingleOrDefaultAsync(x => x.Id == userNotification.NotificationId);
			m_mapper.Map(userNotification, oldNotification);

			//m_context.Attach(notification);
			//m_context.Entry(notification).State = EntityState.Modified;
			await m_context.SaveChangesAsync();
		}

		// проверочный метод
		public async Task<IEnumerable<UserNotification>> GetAll()
		{
			Data.Models.Notification[] result = m_context.Notifications.AsNoTracking()
				.Include(x => x.User).ToArray();

            UserNotification[] mapped = m_mapper.Map<UserNotification[]>(result);

			return await Task.FromResult(mapped.AsEnumerable());
		}

		public async Task<UserNotification> GetNotification(string notificationId)
		{
			return m_mapper.Map<UserNotification>(await m_context.Notifications.AsNoTracking().FirstAsync(x => x.Id == notificationId));
		}

		public async Task<IEnumerable<UserNotification>> GetUserNotifications(string userId, bool onlyOpen)
		{
			Data.Models.Notification[] result = m_context.Notifications.AsNoTracking()
				.Include(x => x.User).Where(x => x.User.Id == userId && x.IsClosed != onlyOpen).ToArray();

			UserNotification[] mapped = m_mapper.Map<UserNotification[]>(result);

			return await Task.FromResult(mapped.AsEnumerable());
		}

		public async Task SetStatusClosed(string notificationId)
		{
			Data.Models.Notification notification = await m_context.Notifications.SingleOrDefaultAsync(x => x.Id == notificationId);
			notification.IsClosed = true;
			await m_context.SaveChangesAsync();
		}

		public void Dispose()
		{
			m_context.Dispose();
		}
	}
}