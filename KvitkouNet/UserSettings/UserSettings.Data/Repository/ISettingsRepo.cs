using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserSettings.Data.DbModels;

namespace UserSettings.Data
{
	public interface ISettingsRepo
	{
		Task<bool> UpdateEmail(string id, string email);

		Task UpdatePassword(string id, string password);

		Task UpdateProfile(string id, ProfileDb profile);
	}
}
