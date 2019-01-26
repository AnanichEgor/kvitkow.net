using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Chat.Data.DbModels;
using Chat.Data.Repositories;
using Chat.Logic.Models;
using FluentValidation;

namespace Chat.Logic.Services
{
    public class RoomService : IRoomService
    {
        private readonly IChatRepository _context;
        private readonly IMapper _mapper;
        private readonly IValidator _validator;
        public RoomService(IChatRepository context, IMapper mapper, IValidator<Room> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
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
            var res = await _context.SearchRoom(template);
            return res == null ? null : _mapper.Map<IEnumerable<Room>>(res);
        }

        public async Task<IEnumerable<Message>> GetMessages(string roomId, string userId)
        {
            var res = await _context.GetMessages(roomId, userId);
            return res == null ? null : _mapper.Map<IEnumerable<Message>>(res);
        }

        public async Task<IEnumerable<Message>> SearchMessage(string roomId, string template)
        {
            var res = await _context.SearchMessage(roomId, template);
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
            _context.Dispose();
        }

        #endregion
    }
}
