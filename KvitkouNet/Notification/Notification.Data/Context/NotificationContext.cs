using Microsoft.EntityFrameworkCore;
using Notification.Data.Models;

namespace Notification.Data.Context
{
	public class NotificationContext : DbContext
	{
		public NotificationContext(DbContextOptions<NotificationContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		DbSet<User> Users { get; set; }

		DbSet<Models.Notification> Notifications { get; set; }
	}
}
