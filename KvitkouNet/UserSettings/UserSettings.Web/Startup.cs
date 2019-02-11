using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using UserSettings.Logic;
using AutoMapper;
using UserSettings.Logic.MappingProfile;
using UserSettings.Data.Context;
using UserSettings.Data.Faker;
using EasyNetQ;
using UserSettings.Web.Subscribers;
using System.Reflection;

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
			//services.AddDbContext<SettingsContext>(
			//	opt => opt.UseSqlite(connectionString: "DataSource=./Database.db"));
			//var o = new DbContextOptionsBuilder<SettingsContext>();
			//o.UseSqlite("DataSource=./Database.db");
			//using (var ctx = new SettingsContext(o.Options))
			//{
			//	ctx.Database.Migrate();
			//	if (!ctx.Settings.Any())
			//	{
			//		ctx.SaveChanges();
			//	}
			//}
			//services.AddAutoMapper(cfg =>
			//{
			//	cfg.AddProfile<SettingsProfile>();
			//	cfg.AddProfile<NotificationsProfile>();
			//});
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			services.AddSwaggerDocument(setting => setting.Title = "User Setting");
			//services.AddSingleton(RabbitHutch.CreateBus("host=localhost;virtualHost=/;username=guest;password=guest"));
			services.RegisterUserSettingsService();
			services.RegisterEasyNetQ("host=localhost");
			services.RegisterConsumers();
			services.AddCors();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseCors(b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
			app.UseSwagger().UseSwaggerUi3();
			app.UseSubscriber("UserSettings", Assembly.GetExecutingAssembly());
			app.UseMvc();
		}
	}
}
