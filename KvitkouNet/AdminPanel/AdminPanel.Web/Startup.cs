using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AdminPanel.Web.Extensions;
using AutoMapper;
using EasyNetQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AdminPanel.Web
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
			var assemblyNamesToScan = Assembly
				.GetEntryAssembly()
				.GetReferencedAssemblies()
				.Where(an => an.FullName.StartsWith("AdminPanel", StringComparison.OrdinalIgnoreCase))
				.Select(an => an.FullName);

			services.AddAutoMapper(cfg => cfg.AddProfiles(assemblyNamesToScan));

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddSwaggerDocument();

			services.RegisterUserService();
			services.RegisterLoggingService();
			services.RegisterFilters();

			services.AddSingleton(RabbitHutch.CreateBus("host=localhost"));
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
