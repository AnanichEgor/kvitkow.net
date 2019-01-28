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

		/// <summary>
		/// Обновление email в бд
		/// </summary>
		/// <param name="id">id пользователя</param>
		/// <param name="email">новый email</param>
		/// <returns></returns>
		public async Task<bool> UpdateEmail(string id, string email)
		{
			var origin = await _context.Settings.SingleOrDefaultAsync(x => x.UserId == id);
			await _context.Accounts.LoadAsync();
			if (origin != null)
			{
				origin.Account.Email = email;
				await _context.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<IEnumerable<SettingsDb>> ShowAll()
		{
			return await _context.Settings
				.Include(db => db.Profile)
				.Include(db => db.Profile.Notifications)
				.Include(db => db.Account)
				.AsTracking()
				.ToListAsync();
		}

		public async Task<bool> UpdatePassword(string id, string currentPass, string newPass)
		{
			var origin = await _context.Settings.SingleOrDefaultAsync(x => x.UserId == id);
			await _context.Accounts.LoadAsync();
			if (origin != null)
			{
				if (origin.Account.Password == currentPass)
				{
					origin.Account.Password = newPass;
					await _context.SaveChangesAsync();
					return true;
				}
				return false;
			}
			return false;
		}

		public async Task<bool> UpdateProfile(string id, string first, string middle, string last)
		{
			var origin = await _context.Settings.SingleOrDefaultAsync(x => x.UserId == id);
			await _context.Profiles.LoadAsync();
			if (origin != null)
			{
				origin.Profile.FirstName = first;
				origin.Profile.MiddleName = middle;
				origin.Profile.LastName = last;
				await _context.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<bool> CheckExistEmail(string email)
		{
			var	result = await _context.Accounts.FirstOrDefaultAsync(x => x.Email == email);
			return result == null ? false : true;
		}

		public async Task<bool> UpdateNotifications(string id, NotificationDb notifications)
		{
			var origin = await _context.Settings.SingleOrDefaultAsync(x => x.UserId == id);
			await _context.Profiles.LoadAsync();
			await _context.Notifications.LoadAsync();
			if (origin != null)
			{
				origin.Profile.Notifications.IsLikeMyTicket = notifications.IsLikeMyTicket;
				origin.Profile.Notifications.IsWantBuy = notifications.IsWantBuy;
				origin.Profile.Notifications.IsOtherNotification = notifications.IsOtherNotification;
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
