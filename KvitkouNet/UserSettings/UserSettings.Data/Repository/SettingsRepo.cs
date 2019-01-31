using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserSettings.Data.Context;
using UserSettings.Data.DbModels;

namespace UserSettings.Data
{
	/// <summary>
	/// Репозиторий работы с бд
	/// </summary>
	public class SettingsRepo : ISettingsRepo
	{
		private readonly SettingsContext _context;
		public SettingsRepo(SettingsContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<SettingsDb>> ShowAll()
		{
			return await _context.Settings
				.Include(db => db.Notifications)
				.AsTracking()
				.ToListAsync();
		}

		public async Task<bool> UpdateNotifications(string id, NotificationDb notifications)
		{
			var origin = await _context.Settings.SingleOrDefaultAsync(x => x.SettingsId == id);
			if (origin != null)
			{
				origin.Notifications.IsLikeMyTicket = notifications.IsLikeMyTicket;
				origin.Notifications.IsWantBuy = notifications.IsWantBuy;
				origin.Notifications.IsOtherNotification = notifications.IsOtherNotification;
				await _context.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public Task<bool> UpdatePreferences(string id, string address, string region, string place)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAccount(string id)
		{
			throw new NotImplementedException();
		}
	}
}
