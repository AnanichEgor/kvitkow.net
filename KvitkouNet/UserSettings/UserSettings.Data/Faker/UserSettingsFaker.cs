﻿using Bogus;
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
			_fakerSettings.RuleFor(db => db.UserId, faker => faker.Lorem.Word());
			_fakerSettings.RuleFor(db => db.Account, f =>
			{
				var fakerAccount = new Faker<AccountDb>();
				fakerAccount.RuleFor(db => db.Email, faker => faker.Internet.Email());
				fakerAccount.RuleFor(db => db.Password, faker => faker.Lorem.Word());
				return fakerAccount.Generate();
			});
			_fakerSettings.RuleFor(db => db.Profile, f =>
			{
				var fakerProfile = new Faker<ProfileDb>();
				fakerProfile.RuleFor(db => db.FirstName, faker => faker.Name.FirstName());
				fakerProfile.RuleFor(db => db.LastName, faker => faker.Name.LastName());
				fakerProfile.RuleFor(db => db.IsPrivateAccount, true);
				fakerProfile.RuleFor(db => db.PreferRegion, faker => faker.Address.StreetAddress());
				return fakerProfile.Generate();
			});
		}
	}
}
