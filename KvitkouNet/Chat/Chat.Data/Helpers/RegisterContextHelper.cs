using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Chat.Data.Context;
using Chat.Data.Fakers;


namespace Chat.Data.Helpers
{
    public class RegisterContextHelper
    {
        private string m_dataSource = @"Data Source=./ChatDB.db";

        public RegisterContextHelper()
        {
            var o = new DbContextOptionsBuilder<ChatContext>();
            o.UseSqlite(m_dataSource);

            using (var ctx = new ChatContext(o.Options))
            {
                //если нету DB - создадим
                ctx.Database.EnsureCreated();

            }
        }

        public Action<DbContextOptionsBuilder> GetOptionsBuilder()
        {
            return opt => opt.UseSqlite(connectionString: m_dataSource);
        }
    }
}
