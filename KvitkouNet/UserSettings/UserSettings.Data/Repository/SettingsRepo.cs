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
			_context.Accounts.Load();
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

		public Task UpdatePassword(string id, string password)
		{
			throw new NotImplementedException();
		}

		public Task UpdateProfile(string id, ProfileDb profile)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> CheckExistEmail(string email)
		{
			var	result = await _context.Accounts.FirstOrDefaultAsync(x => x.Email == email);
			return result == null ? false : true;
		}
	}
}
