using AutoMapper;
using FluentValidation;
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
		private readonly IValidator<Account> _validatorAccount;
		private readonly IValidator<Models.Profile> _validatorProfile;
		private readonly ISettingsRepo _context;

		public UserSettingsService(IMapper mapper, ISettingsRepo context, IValidator<Account> validatorAccount, IValidator<Models.Profile> validatorProfile)
		{
			_mapper = mapper;
			_validatorAccount = validatorAccount;
			_validatorProfile = validatorProfile;
			_context = context;
		}

		public async Task<IEnumerable<Settings>> ShowAll()
		{
			var res =  await _context.ShowAll();
			var temp = _mapper.Map<IEnumerable<Settings>>(res);
			return _mapper.Map<IEnumerable<Settings>>(res);
		}

		//TODO почту проверять из таблицы юзеров
		public async Task<bool> UpdateEmail(string id, string email)
		{
			//if (!_validator.Validate(email).IsValid)
			//{
			//	return false;
			//}
			if (!await CheckExistEmail(email))
			{
				return await _context.UpdateEmail(id, email);
			}
			else
			{
				return false;
			}
		}

		public async Task SendConfirmEmail(string email, string subject, string message)
		{
			return;
		}

		public async Task<bool> UpdatePassword(string id, string current, string newPass, string confirm)
		{
			if(String.Equals(newPass, confirm))
			{
				if(await _context.UpdatePassword(id, current, newPass))
				{
					return true;
				}
			}
			return false;
		}

		public async Task<bool> UpdateProfile(string id, string first, string middle, string last)
		{
			if (string.IsNullOrEmpty(first))
				return false;
			if(await _context.UpdateProfile(id, first, middle, last))
			{
				return true;
			}
			return false;
		}

		public async Task<bool> CheckExistEmail(string email)
		{
			return await _context.CheckExistEmail(email);
		}

		public async Task<bool> UpdateNotifications(string id, Notifications notifications)
		{
			return await _context.UpdateNotifications(id, _mapper.Map<Notifications, NotificationDb>(notifications));
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
