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

		public Task<bool> UpdateProfile(string id, ProfileDb profile)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> CheckExistEmail(string email)
		{
			var	result = await _context.Accounts.FirstOrDefaultAsync(x => x.Email == email);
			return result == null ? false : true;
		}

		public Task<bool> UpdateNotifications(string id, List<string> notifications)
		{
			throw new NotImplementedException();
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
