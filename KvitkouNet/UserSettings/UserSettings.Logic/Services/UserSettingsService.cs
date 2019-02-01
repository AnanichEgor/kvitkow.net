using AutoMapper;
using EasyNetQ;
using FluentValidation;
using KvitkouNet.Messages.UserSettings;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserSettings.Data;
using UserSettings.Data.DbModels;
using UserSettings.Logic.Models;
using UserSettings.Logic.Models.Helper;

namespace UserSettings.Logic.Services
{
	public class UserSettingsService : IUserSettingsService
	{
		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}

		private readonly IMapper _mapper;
		private readonly IValidator<Settings> _validator;
		private readonly ISettingsRepo _context;
		private readonly IBus _bus;

		public UserSettingsService(IMapper mapper, ISettingsRepo context, IValidator<Settings> validator, IBus bus)
		{
			_mapper = mapper;
			_validator = validator;
			_context = context;
			_bus = bus;
		}

		public async Task<Settings> Get(string id)
		{
			var temp =_bus.RequestAsync<RequestId, UserProfileMessage>(new RequestId(id));
			var res =  await _context.Get(id);
			return _mapper.Map<Settings>(res);
		}

		//TODO почту проверять из таблицы юзеров
		public async Task<ResultEnum> UpdateEmail(string id, string email)
		{
			//if (!_validator.Validate(email).IsValid)
			//{
			//	return false;
			//}
			if(await CheckExistEmail(email))
			{
				return ResultEnum.Success;
			}
			return ResultEnum.Error;
		}

		public async Task<ResultEnum> UpdatePassword(string id, string current, string newPass, string confirm)
		{
			if(String.Equals(newPass, confirm))
			{
				if(await CheckPassword(current, newPass))
				{
					return ResultEnum.Success;
				}
			}
			return ResultEnum.Error;
		}

		private Task<bool> CheckPassword(string current, string newPass)
		{
			throw new NotImplementedException();
		}

		public async Task<ResultEnum> UpdateProfile(string id, string first, string middle, string last, DateTime birthdate)
		{
			if (string.IsNullOrEmpty(first))
				return ResultEnum.Error;
			await _bus.PublishAsync(new UserProfileMessage()
			{
				FirstName = first,
				LastName = last,
				MiddleName = middle,
				Birthday = birthdate
			});
			return ResultEnum.Success;
		}

		public async Task<bool> CheckExistEmail(string email)
		{
			return true;
		}

		public async Task<ResultEnum> UpdateNotifications(string id, Notifications notifications)
		{
			if(await _context.UpdateNotifications(id, _mapper.Map<Notifications, NotificationDb>(notifications)))
			{
				return ResultEnum.Success;
			}
			return ResultEnum.Error;
		}

		public Task<bool> UpdatePreferences(string id, string address, string region, string place)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeleteAccount(string id)
		{
			throw new NotImplementedException();
		}
	}
}
