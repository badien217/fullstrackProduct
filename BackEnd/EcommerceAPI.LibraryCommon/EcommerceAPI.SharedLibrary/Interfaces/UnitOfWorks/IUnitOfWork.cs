using EcommerceAPI.SharedLibrary.Interfaces.EntityBase;
using EcommerceAPI.SharedLibrary.Interfaces.Reponsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.SharedLibrary.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReponsitory<T> GetReponsitory<T>() where T : class, IEntityBase, new();

        Task<int> SaveAsync();
        int Save();
    }
}
