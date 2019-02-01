using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserSettings.Data.DbModels;

namespace UserSettings.Data
{
	public interface ISettingsRepo
	{
		Task<SettingsDb> Get(string id);

		Task<bool> UpdateNotifications(string id, NotificationDb notifications);

		Task<bool> UpdatePreferences(string id, string address, string region, string place);

		Task DeleteAccount(string id);
	}
}
