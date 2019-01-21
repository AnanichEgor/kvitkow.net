using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using Logging.Data;
using Logging.Data.Fakers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Logging.Logic.Helpers
{
	//TODO избавиться от статики, если будет необходимость
	public static class ContextInitializer
	{
		/// <summary>
		/// Метод для инициализации LoggingDbContext
		/// </summary>
		/// <param name="serviceProvider"></param>
		/// <exception cref="DataException">Выбрасывается, если произошла ошибка при инициализации контекста </exception>
		public static void InitializeContext(IServiceProvider serviceProvider)
		{
			const string errorMessage = "Failed to initialize context.";
			try
			{
				var context = serviceProvider.GetRequiredService<LoggingDbContext>();
				context.Database.Migrate();
				SeedInternalErrorLogEntries(context);
			}
			catch (Exception)
			{
				throw new DataException(errorMessage);
			}
		}

		private static void SeedInternalErrorLogEntries(LoggingDbContext context)
		{
			if (!context.InternalErrorLogEntries.Any())
			{
				context.InternalErrorLogEntries.AddRange(InternalErrorLogEntryFaker.Generate());
				context.SaveChanges();
			}
		}
	}
}