using Microsoft.EntityFrameworkCore;
using Notification.Data.Models;

namespace Notification.Data.Context
{
	public class NotificationContext : DbContext
	{
		public NotificationContext(DbContextOptions<NotificationContext> options) : base(options)
		{	}

		public DbSet<User> Users { get; set; }

		public DbSet<Models.Notification> Notifications { get; set; }
	}
}
