using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using Search.Data.Repositories;

namespace Search.Data
{
    public static class HistoryRepositoryExtension
    {
        public static IServiceCollection RegisterHistoryRepository(this IServiceCollection services)
        {
            services.AddScoped<IHistoryRepository, HistoryRepository>();
            return services;
        }
    }
}
