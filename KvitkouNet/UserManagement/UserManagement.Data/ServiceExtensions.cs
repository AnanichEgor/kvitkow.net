using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using UserManagement.Data.Context;
using UserManagement.Data.Fakers;
using UserManagement.Data.Repositories;

namespace UserManagement.Data
{
    public static class ServiceExtentions
    {
        public static IServiceCollection RegisterUserServicesData(this IServiceCollection services)
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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
