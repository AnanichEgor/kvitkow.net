using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Chat.Data.Repositories;
using Chat.Logic.Models;

namespace Chat.Logic.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _context;
        private readonly IMapper _mapper;
      //  private readonly IValidator _validator;

        public ChatService(IChatRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
           // _validator = validator;
        }

        public Task<Settings> GetUserSettings(string userId)
        {
            throw new NotImplementedException();
        }
        public Task EditUserSettings(string userId, Settings settings)
        {
            throw new NotImplementedException();
        }
        public Task EditUserRole(string userId, User settings)
        {
            throw new NotImplementedException();
        }
        public Task AddRoom(Room room, string userId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Room>> GetRooms(string userId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Room>> SearchRoom(string template)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Message>> GetMessagesFromTheRoom(string roomId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Message>> SearchMessage(string roomId, string template)
        {
            throw new NotImplementedException();
        }
        public Task AddMessage(Message message, string roomId)
        {
            throw new NotImplementedException();
        }
        public Task EditMessage(Message message, string roomId)
        {
            throw new NotImplementedException();
        }
        public Task DeleteMessage(string roomId, string messageId)
        {
            throw new NotImplementedException();
        }
        public Task EditSettingIsReeadForMessage(string roomId, string messageId)
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
