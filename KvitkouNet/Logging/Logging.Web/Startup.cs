using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using EasyNetQ;
using Logging.Logic.Extensions;
using Logging.Web.Subscriber;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Logging.Web
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
			services.AddDbContext();

			var assemblyNamesToScan = Assembly
				.GetEntryAssembly()
				.GetReferencedAssemblies()
				.Where(an => an.FullName.StartsWith("Logging", StringComparison.OrdinalIgnoreCase))
				.Select(an => an.FullName);

			services.AddAutoMapper(cfg => cfg.AddProfiles(assemblyNamesToScan));

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddSwaggerDocument();

			services.AddSingleton<IBus>(RabbitHutch.CreateBus("host=localhost"));

			services.RegisterLoggingService();
			services.RegisterValidators();
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

			app.UseSubscriber("ErrorLogging", Assembly.GetExecutingAssembly());
		}
	}
}
