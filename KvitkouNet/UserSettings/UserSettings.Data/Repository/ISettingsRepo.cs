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

		Task<bool> UpdatePassword(string id, string currentPass, string newPass);

		Task<bool> UpdateProfile(string id, string first, string middle, string last);

		Task<IEnumerable<SettingsDb>> ShowAll();

		Task<bool> CheckExistEmail(string email);

		Task<bool> UpdateNotifications(string id, NotificationDb notifications);

		Task<bool> UpdatePreferences(string id, string address, string region, string place);

		Task DeleteAccount(string id);
	}
}
