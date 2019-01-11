using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using UserSettings.Data.Context;
using UserSettings.Logic;

namespace UserSettings.Web
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<SettingsContext>(
				opt => 	opt.UseSqlite(connectionString: "DataSource=./Database.db"));

			var o = new DbContextOptionsBuilder<SettingsContext>();
			o.UseSqlite("Data Source=./Database.db");

			using (var context = new SettingsContext(o.Options))
			{
				context.Database.Migrate();
				if(context.Settings.Any())
				{
					context.SaveChanges();
				}
			}
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			services.AddSwaggerDocument();
			services.RegisterUserSettingsService();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				//DBInitialize.Seed(app);
			}

			app.UseMvc();
			app.UseSwagger().UseSwaggerUi3();
		}
	}
}
