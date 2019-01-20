using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Notification.Data.Context;
using Notification.Logic;
using Notification.Logic.MappingProfiles;
using System.Linq;
using Notification.Data.Fakers;

namespace Notification.Web
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
			services.AddDbContext<NotificationContext>(
				opt => opt.UseSqlite(connectionString: "Data Source = ./Notification.db"));

			var o = new DbContextOptionsBuilder<NotificationContext>();
			o.UseSqlite("Data Source=./Notification.db");
			
			using (var ctx = new NotificationContext(o.Options))
			{
				ctx.Database.Migrate();

				if (!ctx.Notifications.Any())
				{
					ctx.Notifications.AddRange(NotificationFaker.Generate(50));
					ctx.SaveChanges();
				}
			}

			services.AddAutoMapper(cfg =>
			{
				cfg.AddProfile<NotificationMessageProfile>();
				cfg.AddProfile<UserNotificationProfile>();
				cfg.AddProfile<EmailNotificationProfile>();				
			});

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddSwaggerDocument();

			services.RegisterNotificationService();
			services.RegisterEmailNotificationService();
			services.RegisterEmailSenderService();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger().UseSwaggerUi3();

			app.UseMvc();
		}
	}
}
