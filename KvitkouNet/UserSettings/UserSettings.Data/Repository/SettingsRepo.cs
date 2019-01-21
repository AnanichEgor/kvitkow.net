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
	public class SettingsRepo : ISettingsRepo
	{
		private readonly SettingsContext _context;
		public SettingsRepo(SettingsContext context)
		{
			_context = context;
		}
		public async Task<bool> UpdateEmail(string id, string email)
		{
			var origin = await _context.Settings.SingleOrDefaultAsync(x => x.UserId == id);
			_context.Accounts.Load();
			if(origin != null)
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

		public async Task<SettingsDb> Get(int id)
		{
			return await _context.Settings
				.Include(db => db.Profile)
				.Include(db => db.Account)
				.AsTracking()
				.FirstAsync();
		}

		public Task UpdatePassword(string id, string password)
		{
			throw new NotImplementedException();
		}

		public Task UpdateProfile(string id, ProfileDb profile)
		{
			throw new NotImplementedException();
		}
	}
}
