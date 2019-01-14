using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StatisticOnline.Data.Context;
using StatisticOnline.Data.Fakers;

namespace StatisticOnline.Logic.Services
{
    public class ContextInit
    {


        /// <summary>
        /// Метод для инициализации WebApiContext
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <exception cref="DataException">ошибка при инициализации контекста </exception>

        public static void InitContext(IServiceProvider serviceProvider)
        {
            const string errorMessage = "Failed to initialize context.";
            try
            {
                var context = serviceProvider.GetRequiredService<WebApiContext>();
                context.Database.Migrate();
                if (!context.StatisticOnline.Any())
                {
                    context.StatisticOnline.AddRange(StatisticOnlineFaker.Generate(150));
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new DataException(errorMessage);
            }
        }
    }
}
