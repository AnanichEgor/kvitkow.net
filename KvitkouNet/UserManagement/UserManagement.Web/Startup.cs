using UserManagement.Logic;
using UserManagement.Data.Context;
using UserManagement.Data.Fakers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using UserManagement.Logic.Models;
using FluentValidation;
using UserManagement.Logic.Validators;
using UserManagement.Logic.MappingProfiles;
using AutoMapper;
using System.Linq;

namespace UserManagement.Web
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
            services.AddDbContext<UserContext>(opt => opt.UseSqlite("Data Source=./UserDatabase.db"));
            var o = new DbContextOptionsBuilder<UserContext>();
            o.UseSqlite("Data Source=./UserDatabase.db");

            using (var context = new UserContext(o.Options))
            {
                context.Database.Migrate();
                if (!context.Users.Any())
                {
                    context.Users.AddRange(UserFaker.Generate());
                    context.SaveChanges();
                }
            }
            services.AddAutoMapper(cfg=>
            {
                cfg.AddProfile<UserProfile>();
            });
            services.AddScoped<IValidator<User>, UserValidator>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerDocument();
            services.RegisterUserServices();
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
