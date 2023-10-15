using Eatstead.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valuegate.Infrastructure.Data;

namespace Valuegate.Infrastructure.Repositories
{
    public class UnitOfWork : IDisposable
    {

        ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private GenericRepository<Menu, int> menuRepository;

        private GenericRepository<Cafeteria, int> cafeteriaRepository;
        public GenericRepository<Menu, int> MenuRepository
        {
            get
            {
                if (menuRepository == null)
                {
                    menuRepository = new GenericRepository<Menu, int>(_context);
                }
                return menuRepository;
            }
        }

        public GenericRepository<Cafeteria, int> CafeteriaRepository
        {
            get
            {
                if (cafeteriaRepository == null)
                {
                    cafeteriaRepository = new GenericRepository<Cafeteria, int>(_context);
                }
                return cafeteriaRepository;
            }
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
            GC.SuppressFinalize(this);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
