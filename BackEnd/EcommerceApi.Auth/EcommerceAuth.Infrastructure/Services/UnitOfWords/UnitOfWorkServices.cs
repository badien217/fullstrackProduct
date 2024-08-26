using EcommerceAPI.SharedLibrary.Interfaces.Reponsitories;
using EcommerceAPI.SharedLibrary.Interfaces.UnitOfWorks;
using EcommerceAuth.Infrastructure.context;
using EcommerceAuth.Infrastructure.Services.Reponsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAuth.Infrastructure.Services.UnitOfWords
{
    public class UnitOfWorkServices : IUnitOfWork
    {
        private readonly AddDbContext _dbContext;
        public UnitOfWorkServices(AddDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();

        public int Save() => _dbContext.SaveChanges();

        public async Task<int> SaveAsync() => await _dbContext.SaveChangesAsync();

        IReponsitory<T> IUnitOfWork.GetReponsitory<T>() => new ReponsitoryServices<T>(_dbContext);

    }
}
