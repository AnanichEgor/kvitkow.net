using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using EasyNetQ;
using Notification.Logic;
using Notification.Logic.MappingProfiles;
using Notification.Web.Configs;


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
			services.AddAutoMapper(cfg =>
			{
				cfg.AddProfile<NotificationMessageProfile>();
				cfg.AddProfile<UserNotificationProfile>();
				cfg.AddProfile<EmailNotificationProfile>();				
			});

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddSwaggerDocument();

			services.RegisterNotificationContext();
			services.RegisterNotificationService();
			services.RegisterEmailNotificationService();
			services.RegisterEmailSenderService();

			services.AddSingleton<IBus>(RabbitHutch.CreateBus("host=localhost"));
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
