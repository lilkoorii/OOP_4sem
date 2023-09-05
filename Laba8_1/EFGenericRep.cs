using Laba9;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba9
{
    class EFGenericRep<TEntity> : InterfaceGenericRep<TEntity> where TEntity : class
    {
        Microsoft.EntityFrameworkCore.DbContext _context;//ссылка на контекст
        Microsoft.EntityFrameworkCore.DbSet<TEntity> _dbSet;

        public EFGenericRep(Microsoft.EntityFrameworkCore.DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()//получаем значения
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }
        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(TEntity item)
        {
            _dbSet.Attach(item);
            _context.SaveChangesAsync();
        }
        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }
        public void Remove(TEntity item)
        {
            _context.Entry(item).State = EntityState.Deleted;
            _dbSet.Remove(item);
            _context.SaveChangesAsync();
        }
    }
}