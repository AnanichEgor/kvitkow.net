using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Notification.Data.Context;
using Notification.Data.Fakers;

namespace Notification.Data.Helpers
{
	public class RegisterContextHelper
	{
		private string m_dataSource = "Data Source=./Notification.db";

		public RegisterContextHelper()
		{
			var o = new DbContextOptionsBuilder<NotificationContext>();
			o.UseSqlite(m_dataSource);

			using (var ctx = new NotificationContext(o.Options))
			{
				ctx.Database.Migrate();

				if (!ctx.Notifications.Any())
				{
					ctx.Notifications.AddRange(NotificationFaker.Generate(50));
					ctx.SaveChanges();
				}
			}
		}

		public Action<DbContextOptionsBuilder> GetOptionsBuilder()
		{
			return opt => opt.UseSqlite(connectionString: m_dataSource);
		}
	}
}