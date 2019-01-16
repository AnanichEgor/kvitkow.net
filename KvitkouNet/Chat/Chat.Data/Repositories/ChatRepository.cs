using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Data.Context;
using Chat.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Chat.Data.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly ChatContext _context;

        public ChatRepository(ChatContext context)
        {
            _context = context;
        }
        public  Task<SettingsDb> GetUserSettings(string userId)
        {
            return  _context.Settings
                .Include(db => db.User)
                .SingleOrDefaultAsync( x => x.User.Id.Equals(userId));
        }
        public async Task UpdateUserSettings(string userId, SettingsDb settings)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateUserRole(string userId, UserDb settings)
        {
            throw new NotImplementedException();
        }
        public async Task AddRoom(RoomDb room, string userId)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<RoomDb>> GetRooms(string userId)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<RoomDb>> SearchRoom(string template)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<MessageDb>> GetMessagesFromTheRoom(string roomId)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<MessageDb>> SearchMessage(string roomId, string template)
        {
            throw new NotImplementedException();
        }
        public async Task AddMessage(MessageDb message, string roomId)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateMessage(MessageDb message, string roomId)
        {
            throw new NotImplementedException();
        }
        public async Task DeleteMessage(string roomId, string messageId)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateSettingIsReeadForMessage(string roomId, string messageId)
        {
            throw new NotImplementedException();
        }
    }
}
