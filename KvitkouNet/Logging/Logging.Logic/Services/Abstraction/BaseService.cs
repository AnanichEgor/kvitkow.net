using System;
using AutoMapper;
using Logging.Data;

namespace Logging.Logic.Services.Abstraction
{
    public class BaseService : IDisposable
    {
        private bool _disposed;

        public BaseService(LoggingDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        protected LoggingDbContext Context { get; }

        protected IMapper Mapper { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                Context?.Dispose();
            }

            _disposed = true;
        }
    }
}
