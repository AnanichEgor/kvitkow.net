using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Dashboard.Logic;
using AutoMapper;
<<<<<<< HEAD
using Dashboard.Logic.Models;
using Dashboard.Logic.Validators;
using Dashboard.Data.Context;
using Dashboard.Data.Fakers;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Dashboard.Logic.MappingProfiles;
=======
>>>>>>> DashboardMicroservice

namespace DashboardMicroService
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
<<<<<<< HEAD
            services.AddDbContext<DashboardContext>(opt => opt.UseSqlite("Data Source=./DashboardDatabase.db"));
            var o = new DbContextOptionsBuilder<DashboardContext>();
            o.UseSqlite("Data Source =./DashboardDatabase.db");


            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<NewsProfile>();
                cfg.AddProfile<TicketInfoProfile>();
                cfg.AddProfile<UserInfoProfile>();
            });

            services.AddAutoMapper();
            services.AddScoped<IValidator<News>, NewsValidator>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
=======
            services.AddAutoMapper();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

>>>>>>> DashboardMicroservice
            services.AddSwaggerDocument();
            services.RegisterDashboardService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseSwagger().UseSwaggerUi3();
            app.UseMvc();
        }
    }
}
