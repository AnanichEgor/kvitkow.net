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
		private readonly IValidator _validator;
		private readonly ISettingsRepo _context;

		public UserSettingsService(IMapper mapper, IValidator validator, ISettingsRepo context)
		{
			_mapper = mapper;
			_validator = validator;
			_context = context;
		}

		public async Task<IEnumerable<Settings>> ShowAll()
		{
			var res =  await _context.ShowAll();
			var temp = _mapper.Map<IEnumerable<Settings>>(res);
			return _mapper.Map<IEnumerable<Settings>>(res);
		}

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
			if (!_validator.Validate(email).IsValid)
				return;

			var emailMessage = new MimeMessage();

			emailMessage.From.Add(new MailboxAddress("Confirm email", "login@yandex.ru"));
			emailMessage.To.Add(new MailboxAddress("", email));
			emailMessage.Subject = subject;
			emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
			{
				Text = message
			};
			using (var client = new SmtpClient())
			{
				await client.ConnectAsync("smtp.yandex.ru", 25, false);
				await client.AuthenticateAsync("login@yandex.ru", "password");
				await client.SendAsync(emailMessage);
				await client.DisconnectAsync(true);
			}
		}

		public Task<ActionResult> UpdatePassword(string id, string current, string newPass, string confirm)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult> UpdateProfile(string id, Models.Profile profile)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> CheckExistEmail(string email)
		{
			return await _context.CheckExistEmail(email);
		}
	}
}
