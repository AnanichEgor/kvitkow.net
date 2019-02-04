using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Chat.Data.Context;
using Chat.Data.DbModels;
using Chat.Logic.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Chat.Logic.Services
{
    public class ChatService : IChatService
    {
        private readonly ChatContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator _validator;

        public ChatService(ChatContext context, IMapper mapper, IValidator<Settings> validator)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Settings> GetUserSettings(string userId)
        {
            var res = await _context.Settings.SingleOrDefaultAsync(x => x.UserId == userId);
            return res == null ? null : _mapper.Map<Settings>(res);
        }

        public async Task EditUserSettings(string userId, Settings settings)
        {
           
            var res = await _context.Settings.SingleOrDefaultAsync(x => x.UserId == userId);
            if (res == null)
            {
                await Task.FromException(new InvalidDataException());
            }
            else
            {
                var modelDb = _mapper.Map<SettingsDb>(settings);
                modelDb.UserId = userId;
                _context.Attach(modelDb);
                _context.Entry(modelDb).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        #region IDisposable Support

        public void Dispose()
        {
            _context.Dispose();
        }

        #endregion
    }
}
