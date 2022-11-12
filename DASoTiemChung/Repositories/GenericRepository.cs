using DASoTiemChung.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DASoTiemChung.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SoTiemChungContext _context = null;
        private readonly DbSet<T> table = null;
        public GenericRepository()
        {
            this._context = new SoTiemChungContext();
            table = _context.Set<T>();
        }
        public GenericRepository(SoTiemChungContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.AsEnumerable();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
