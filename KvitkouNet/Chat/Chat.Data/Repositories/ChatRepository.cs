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
                    .SingleOrDefaultAsync( x => x.User.Id.Equals(userId));
        }

        // todo Что возвращать при Update и когда для Save использовать await. И нужно ли в этом случае тогда передавать еще userId?
        public async Task UpdateUserSettings(string userId, SettingsDb settings)
        {
            _context.Settings.Update(settings);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserRole(string userId, UserDb user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task AddRoom(RoomDb room, string userId)
        {
            room.OwnerId = userId;
            await _context.Rooms.AddAsync(room);
        }

        // todo нужно добавить еще условие для выборки всех приватных комнат и соответственно доработать модель
        public async Task<IEnumerable<RoomDb>> GetRooms(string userId)
        {
            return _context.Rooms.Where(x => x.IsPrivat == false);
        }

        // todo надо разобраться с  асинхронным запуском
        public async Task<IEnumerable<RoomDb>> SearchRoom(string template)
        {
            return _context.Rooms.Where(x => EF.Functions.Like(x.Name, $"%{template}%"));
        }

        public async Task<IEnumerable<MessageDb>> GetMessages(string roomId)
        {
            return _context.Messages.Where(x => x.RoomId.Equals(roomId));
        }

        //todo  здесь where.where - это как условие AND ?
        public async Task<IEnumerable<MessageDb>> SearchMessage(string roomId, string template)
        {
            return _context.Messages.Where(x => x.Room.Id.Equals(roomId)).Where(x => EF.Functions.Like(x.Text, $"%{template}%"));
        }

        public async Task AddMessage(MessageDb message, string roomId)
        {
            message.RoomId = roomId;
            await _context.Messages.AddAsync(message);
        }
        // todo тот же вопрос с update
        public async Task UpdateMessage(MessageDb message, string roomId)
        {
            _context.Messages.Update(message);
            await _context.SaveChangesAsync();
        }

        // todo как тут удалять правильно?
        public async Task DeleteMessage(string roomId, string messageId)
        {
            _context.Messages.Remove(new MessageDb() {Id = messageId});
            await _context.SaveChangesAsync();
        }

        //todo как обновить конкретное поле если для update нужна вся модель ?
        public async Task UpdateSettingIsReeadForMessage(string roomId, string messageId)
        {
            var oldMessage = _context.Messages.SingleOrDefault(x => x.Id.Equals(messageId));
            if (oldMessage != null)
            {
                oldMessage.IsRead = true;
                var newMessage = oldMessage;
                _context.Messages.Update(newMessage);
            }

            await _context.SaveChangesAsync();
        }
    }
}
