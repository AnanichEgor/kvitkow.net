using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Data.Context;

namespace UserManagement.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly UserContext _context;
        public UnitOfWork(UserContext context)
        {
            _context = context;
        }
        private IUserRepository userRepository;
        private IAccountRepository accountRepository;
        private IGroupRepository groupRepository;

        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(_context);
                return userRepository;
            }
        }

        public IAccountRepository Accounts
        {
            get
            {
                if (accountRepository == null)
                    accountRepository = new AccountRepository(_context);
                return accountRepository;
            }
        }

        public IGroupRepository Groups
        {
            get
            {
                if (groupRepository == null)
                    groupRepository = new GroupRepository(_context);
                return groupRepository;
            }
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
