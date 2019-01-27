﻿using System.Threading.Tasks;
using AutoMapper;
using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using KvitkouNet.Messages.Logging;
using Logging.Logic.Infrastructure;
using Logging.Logic.Models;

namespace Logging.Web.Subscriber
{
	/// <summary>
	/// Класс для обработки сообщений об ошибках с микросервисов
	/// </summary>
	public class InternalErrorLogConsumer : IConsumeAsync<InternalErrorLogEntryMessage>
	{
		private readonly IMapper _mapper;
		private readonly IErrorLogService _errorLogService;

		public InternalErrorLogConsumer(IMapper mapper, IErrorLogService errorLogService)
		{
			_mapper = mapper;
			_errorLogService = errorLogService;
		}

		/// <summary>
		/// Метод для обработки сообщений об ошибке
		/// </summary>
		/// <param name="message">Сообщение об ошибке</param>
		/// <returns></returns>
		[AutoSubscriberConsumer(SubscriptionId = "ErrorLogging.Added")]
		public async Task ConsumeAsync(InternalErrorLogEntryMessage message)
		{
			await _errorLogService.AddLogAsync(_mapper.Map<InternalErrorLogEntry>(message));
		}
	}
}