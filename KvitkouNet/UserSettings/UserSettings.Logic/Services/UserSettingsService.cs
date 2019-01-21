using AutoMapper;
using FluentValidation;
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
			foreach(Settings item in temp)
			{
				
			}
			return _mapper.Map<IEnumerable<Settings>>(res);
		}

		public async Task<bool> UpdateEmail(string id, string email)
		{
			//if (!_validator.Validate(email).IsValid)
			//	return false;
			return await _context.UpdateEmail(id, email); 
		}

		public Task<ActionResult> UpdatePassword(string id, string current, string newPass, string confirm)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult> UpdateProfile(string id, Models.Profile profile)
		{
			throw new NotImplementedException();
		}
	}
}
