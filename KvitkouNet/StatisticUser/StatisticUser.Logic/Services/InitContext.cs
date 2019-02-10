using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StatisticUser.Data;

namespace StatisticUser.Logic.Services
{
    public static class InitContext
    {
        /// <summary>
        /// Метод для инициализации WebApiContext
        /// </summary>
        public static void InitializeContext(IServiceProvider serviceProvider)
        {
            const string errorMessage = "Failed to initialize context.";
            try
            {
                var context = serviceProvider.GetRequiredService<WebApiContext>();
                context.Database.Migrate();
            }
            catch (Exception)
            {
                throw new DataException(errorMessage);
            }
        }
   }
}
