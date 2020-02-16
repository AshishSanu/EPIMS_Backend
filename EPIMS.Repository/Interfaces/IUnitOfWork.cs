using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPIMS.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class;

        void Save();

        Task<int> SaveAsync();

        void Dispose(bool disposing);
    }
}
