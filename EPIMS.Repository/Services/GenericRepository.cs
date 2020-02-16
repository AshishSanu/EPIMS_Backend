using EPIMS.Data.Models;
using EPIMS.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPIMS.Repository.Services
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly EPIMSContext _DbContext;
        private readonly DbSet<T> _DbSet;

        public GenericRepository(EPIMSContext context)
        {
            _DbContext = context;
            this._DbSet = this._DbContext.Set<T>();
        }

        public void Add(T entity)
        {
            var res = this._DbSet.Add(entity);
            Console.WriteLine(res);
        }

        public void Delete(T entity)
        {
            this._DbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return this._DbSet.ToList();
        }
        public T GetById(int id)
        {
            return this._DbSet.Find(id);
        }

        public void Update(T entity)
        {
            this._DbSet.Attach(entity);
            this._DbContext.Entry(entity).State = EntityState.Modified;
        }

        // Fire and forget
        public IEnumerable<T> ExecuteWithStoreProcedure(string query)
        {
            return this._DbSet.FromSqlRaw(query).ToList();
        }
        public IEnumerable<T> ExecuteWithStoreProcedure(string query, params object[] parameters)
        {
            return this._DbSet.FromSqlRaw(query, parameters).ToList();
        }

        // Fire and forget (async)
        public async Task ExecuteWithStoreProcedureAsync(string query, params object[] parameters)
        {
            await this._DbSet.FromSqlRaw(query, parameters).ToListAsync();
        }

    }
}
