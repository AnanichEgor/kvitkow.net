using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.Data.Context;
using Chat.Data.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Chat.Data.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly ChatContext _context;

        public ChatRepository(ChatContext context)
        {
            _context = context;
        }

        public async Task<SettingsDb> GetUserSettings(string userId)
        {
            return await _context.Settings
                    .SingleOrDefaultAsync( x => x.User.Id.Equals(userId));
        }

        public async Task UpdateUserSettings(string userId, SettingsDb settings)
        {
            await Task.Run(() => _context.Settings.Update(settings));
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserRole(string userId, UserDb user)
        {
            await Task.Run(() => _context.Users.Update(user));
            await _context.SaveChangesAsync();
        }

        // todo нужно добавить еще условие для выборки всех приватных комнат и соответственно доработать модель
        public async Task<IEnumerable<RoomDb>> GetRooms(string userId)
        {
            return await _context.Rooms.Where(x => x.IsPrivat == false).ToArrayAsync();
        }

        public async Task AddRoom(RoomDb room, string userId)
        {
            room.OwnerId = userId;
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RoomDb>> SearchRoom(string template)
        {
            return await _context.Rooms.Where(x => EF.Functions.Like(x.Name, $"%{template}%")).ToArrayAsync();
        }

        // todo подумать как ограничить по истории. Или отдельно лезть в таблцу за значением и отсекать потом в БЛ или есть команды в БД
        public async Task<IEnumerable<MessageDb>> GetMessages(string roomId, string userId)
        {
            return await _context.Messages.Where(x => x.RoomId.Equals(roomId)).ToArrayAsync();
        }

        //todo  здесь where.where - это как условие AND ?
        public async Task<IEnumerable<MessageDb>> SearchMessage(string roomId, string template)
        {
            return await _context.Messages.Where(x => x.RoomId.Equals(roomId))
                .Where(x => EF.Functions.Like(x.Text, $"%{template}%")).ToArrayAsync();
        }

        // todo надо окончательно понимать что будет приходить на вход в контроллер, полная модель или нужна доп инфа
        public async Task AddMessage(MessageDb message, string roomId)
        {
            message.RoomId = roomId;
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMessage(MessageDb message, string roomId)
        {
            await  Task.Run(() => _context.Messages.Update(message));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMessage(string roomId, string messageId)
        {
            await Task.Run(() =>_context.Messages.Remove(new MessageDb() {Id = messageId}));
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSettingIsReeadForMessage(string roomId, string messageId)
        {
            var message = await _context.Messages.SingleOrDefaultAsync(x => x.Id.Equals(messageId));
            if (message != null)
            {
                message.IsRead = true;
            }
            await _context.SaveChangesAsync();
        }

        #region IDisposable Support

        public void Dispose()
        {
            _context.Dispose();
        }
        #endregion
    }
}
