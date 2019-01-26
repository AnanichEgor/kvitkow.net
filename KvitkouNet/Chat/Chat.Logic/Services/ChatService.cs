using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Chat.Data.DbModels;
using Chat.Data.Repositories;
using Chat.Logic.Models;
using FluentValidation;

namespace Chat.Logic.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _context;
        private readonly IMapper _mapper;

        public ChatService(IChatRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Settings> GetUserSettings(string userId)
        {
            var res = await _context.GetUserSettings(userId);
            return res == null ? null : _mapper.Map<Settings>(res);
        }

        public async Task EditUserSettings(string userId, Settings settings)
        {
            var modelDb = _mapper.Map<SettingsDb>(settings);
            await _context.UpdateUserSettings(userId, modelDb);

        }

        public async Task EditUserRole(string userId, User user)
        {
            var modelDb = _mapper.Map<UserDb>(user);
            await _context.UpdateUserRole(userId, modelDb);
        }

        #region IDisposable Support

        public void Dispose()
        {
             _context.Dispose();
        }

        #endregion
    }
}
