using System;
using System.Collections.Generic;
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
			var origin = await _context.Settings.FindAsync(id);
			if(origin != null)
			{
				origin.Account.Email = email;
				await _context.SaveChangesAsync();
				return true;
			}
			return false;
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
