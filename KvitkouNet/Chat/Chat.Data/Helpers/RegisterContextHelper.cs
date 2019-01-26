using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Chat.Data.Context;
using Chat.Data.Fakers;


namespace Chat.Data.Helpers
{
    public class RegisterContextHelper
    {
        private string m_dataSource = "Data Source=./Notification.db";

        public RegisterContextHelper()
        {
            var o = new DbContextOptionsBuilder<ChatContext>();
            o.UseSqlite(m_dataSource);

            using (var ctx = new ChatContext(o.Options))
            {
                ctx.Database.Migrate();

                if (!ctx.Rooms.Any())
                {
                    ctx.Rooms.AddRange(RoomFaker.Generate(50));
                    ctx.SaveChanges();
                }
            }
        }

        public Action<DbContextOptionsBuilder> GetOptionsBuilder()
        {
            return opt => opt.UseSqlite(connectionString: m_dataSource);
        }
    }
}
