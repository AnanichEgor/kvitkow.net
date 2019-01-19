﻿using System.Threading.Tasks;
using AdminPanel.Logic.Generated.Logging.Models;
using AutoMapper;
using EasyNetQ;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdminPanel.Web.Filters
{
	public class GlobalExceptionFilter : ExceptionFilterAttribute
	{
		private readonly IBus _bus;
		private readonly IMapper _mapper;

		public GlobalExceptionFilter(IBus bus, IMapper mapper)
		{
			_bus = bus;
			_mapper = mapper;
		}

		public override Task OnExceptionAsync(ExceptionContext context)
		{
			_bus.Publish(_mapper.Map<InternalErrorLogEntry>(context.Exception));
			return base.OnExceptionAsync(context);
		}
	}
}