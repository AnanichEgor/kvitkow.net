using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TicketManagement.Data.Context;
using TicketManagement.Data.Repositories;
using TicketManagement.Logic;
using TicketManagement.Logic.MappingProfiles;
using TicketManagement.Logic.Models;
using TicketManagement.Logic.Validators;
namespace TicketManagement.Web
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
            services.AddDbContext<TicketContext>(opt => opt.UseSqlite("Data Source=./TicketDatabase.db"));

            var o = new DbContextOptionsBuilder<TicketContext>();
            o.UseSqlite("Data Source=./MyFirstDatabase.db");

            using (var ctx = new TicketContext(o.Options))
            {
                ctx.Database.Migrate();

                if (!ctx.Tickets.Any())
                {                    
                    ctx.SaveChanges();
                }
            }

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerDocument();
            services.AddScoped<ITicketRepository>(provider => new TicketRepository(provider.GetService<TicketContext>()));
            services.RegisterTicketService();
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<TicketProfile>();
                cfg.AddProfile<AddressProfile>();
            });

            services.AddScoped<IValidator<Ticket>, TicketValidator>();
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
