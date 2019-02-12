using System.Reflection;
using AutoMapper;
using Chat.Logic;
using Chat.Web.Filters;
using Chat.Web.Hub;
using Chat.Web.MappingProfiles;
using Chat.Web.Subscriber;
using EasyNetQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Web
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
            var rabbitConnectionString = Configuration.GetConnectionString("RabbitConnection");
            services.AddSignalR();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .WithOrigins("http://localhost:4200"));
            });
            services.AddMvc(opt => opt.Filters.Add(new CustomExceptionFilter()))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerDocument(settings => settings.Title = "Chat");
            services.RegisterChatService();
            services.RegisterRoomService();
            services.RegisterDbContext();
            services.RegisterAutoMapperLogic();
            services.AddAutoMapper(cfg => cfg.AddProfile<UserCreationProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<UserUpdatedProfile>());
            services.AddSingleton<IBus>(RabbitHutch.CreateBus(rabbitConnectionString));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsPolicy");
            app.UseSignalR(builder => builder.MapHub<NotificationHub>("/chat/notification"));
            app.UseWebSockets();          
            app.UseSwagger().UseSwaggerUi3();
            app.UseMvc();

            app.UseSubscriber("UserService", Assembly.GetExecutingAssembly());
        }
    }
}
