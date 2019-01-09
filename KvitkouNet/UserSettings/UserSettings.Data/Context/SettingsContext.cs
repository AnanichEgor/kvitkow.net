using Microsoft.EntityFrameworkCore;
using UserSettings.Data.DbModels;

namespace UserSettings.Data.Context
{
	public class SettingsContext: DbContext
	{
		public SettingsContext(DbContextOptions options)
			: base(options)
		{

		}
		public DbSet<ProfileDb> Profiles { get; set; }
		public DbSet<AccountDb> Accounts { get; set; }
	}
}
