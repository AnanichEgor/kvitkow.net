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
        private readonly IValidator _validator;

        public ChatService(IChatRepository context, IMapper mapper, IValidator<Room> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Settings> GetUserSettings(string userId)
        {
            var res = await _context.GetUserSettings(userId);
            return res == null ? null : _mapper.Map<Settings>(res);
        }

        // todo тот эе вопрос. Почему здесь уже нету return и как быть в аткой ситуации
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

        public async Task AddRoom(Room room, string userId)
        {
            var modelDb = _mapper.Map<RoomDb>(room);
            await _context.AddRoom(modelDb, userId);
        }

        public async Task<IEnumerable<Room>> GetRooms(string userId)
        {
            var res = await _context.GetRooms(userId);
            return res == null ? null : _mapper.Map<IEnumerable<Room>>(res);
        }

        public async Task<IEnumerable<Room>> SearchRoom(string template)
        {
            var res = await _context.GetRooms(template);
            return res == null ? null : _mapper.Map<IEnumerable<Room>>(res);
        }

        public async Task<IEnumerable<Message>> GetMessages(string roomId)
        {
            var res = await _context.GetMessages(roomId);
            return res == null ? null : _mapper.Map<IEnumerable<Message>>(res);
        }

        public async Task<IEnumerable<Message>> SearchMessage(string roomId, string template)
        {
            var res = await _context.GetRooms(template);
            return res == null ? null : _mapper.Map<IEnumerable<Message>>(res);
        }

        public async Task AddMessage(Message message, string roomId)
        {
            var modelDb = _mapper.Map<MessageDb>(message);
            await _context.AddMessage(modelDb, roomId);
        }

        public async Task EditMessage(Message message, string roomId)
        {
            var modelDb = _mapper.Map<MessageDb>(message);
            await _context.UpdateMessage(modelDb, roomId);
        }
        public async Task DeleteMessage(string roomId, string messageId)
        {
            await _context.DeleteMessage(roomId, messageId);
        }

        public async Task EditSettingIsReeadForMessage(string roomId, string messageId)
        {
            await _context.UpdateSettingIsReeadForMessage(roomId, messageId);
        }

        #region IDisposable Support

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
