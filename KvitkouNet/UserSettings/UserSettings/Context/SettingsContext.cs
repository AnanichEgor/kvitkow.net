using Microsoft.EntityFrameworkCore;

namespace UserSettings.Context
{
	public class SettingsContext: DbContext
	{
		public SettingsContext(DbContextOptions options)
			: base(options)
		{

		}
	}
}
