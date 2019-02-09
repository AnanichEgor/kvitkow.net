using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Dashboard.Data.Context;
using Dashboard.Data.Fakers;

namespace Dashboard.Data
{
    public static class ServiceExtentions
    {
        public static IServiceCollection RegisterDashboardServicesData(this IServiceCollection services)
        {
            services.AddDbContext<DashboardContext>(opt => opt.UseLazyLoadingProxies().UseSqlite("Data Source=./NewsDatabase.db"));

            var o = new DbContextOptionsBuilder<DashboardContext>();
            o.UseLazyLoadingProxies().UseSqlite("Data Source=./NewsDatabase.db");

            using (var context = new DashboardContext(o.Options))
            {
                context.Database.Migrate();
                context.Database.EnsureCreated();
                if (!context.News.Any())
                {
                    context.News.AddRange(NewsFaker.Generate(3));
                    context.SaveChanges();
                }

            }
            return services;
        }
    }
}