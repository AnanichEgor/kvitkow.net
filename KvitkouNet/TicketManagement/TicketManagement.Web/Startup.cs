using System.Linq;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketManagement.Data.Context;
using TicketManagement.Data.Fakes;
using TicketManagement.Data.Repositories;
using TicketManagement.Logic;
using TicketManagement.Logic.MappingProfiles;
using TicketManagement.Logic.Models;
using TicketManagement.Logic.Services;
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerDocument();
            services.AddScoped<ITicketRepository>(provider =>
                new TicketRepository(new TicketContext(new DbContextOptionsBuilder<TicketContext>()
                    .UseSqlite("Data Source=./TicketDatabase.db").Options)));
            services.RegisterTicketService();
            services.AddScoped<ITicketService>(provider => new TicketService(provider.GetService<ITicketRepository>(),
                provider.GetService<IMapper>(), provider.GetService<IValidator>()));
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<TicketProfile>();
                cfg.AddProfile<AddressProfile>();
                cfg.AddProfile<UserInfoProfile>();
            });
            services.AddScoped<IValidator<Ticket>, TicketValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseSwagger().UseSwaggerUi3();
            app.UseMvc();
        }
    }
}