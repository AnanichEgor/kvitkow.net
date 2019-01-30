using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Data.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        IAccountRepository Accounts { get; }
        IUserRepository Users { get; }
        IGroupRepository Groups { get; }
    }
}
