using Bogus;
using System;
using System.Collections.Generic;
using System.Text;
using UserSettings.Data.DbModels;

namespace UserSettings.Data.Faker
{
	public static class UserSettingsFaker
	{
		private static readonly Faker<SettingsDb> _fakerSettings;
		static UserSettingsFaker()
		{
			_fakerSettings = new Faker<SettingsDb>();
			_fakerSettings.RuleFor(db => db.IsPrivateAccount, true);
			_fakerSettings.RuleFor(db => db.PreferRegion, faker => faker.Address.StreetAddress());
			_fakerSettings.RuleFor(db => db.IsGetTicketInfo, true);
			_fakerSettings.RuleFor(db => db.Notifications, fake =>
			{
				var fakerNotifications = new Faker<NotificationDb>();
				fakerNotifications.RuleFor(db => db.IsLikeMyTicket, false);
				fakerNotifications.RuleFor(db => db.IsOtherNotification, false);
				fakerNotifications.RuleFor(db => db.IsWantBuy, false);
				return fakerNotifications.Generate();
			});
		}

		public static IEnumerable<SettingsDb> Generate(int count = 10)
		{
			return _fakerSettings.Generate(count);
		}
	}
}
