using Microsoft.EntityFrameworkCore;

namespace UserSettings.Web.Context
{
	public class SettingsContext: DbContext
	{
		public SettingsContext(DbContextOptions options)
			: base(options)
		{

		}
	}
}
