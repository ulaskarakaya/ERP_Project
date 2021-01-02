using ERP_Project.DataAccess.Abstraction;
using ERP_Project.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ERP_Project.DataAccess.Concrete.EntityFrameworkCore.EfDals
{
    public class EfBaseDal<TEntity, TContext> : IBaseDal<TEntity>
         where TEntity : class, IEntity, new()
         where TContext : DbContext, new()
    {
        protected TContext _context;
        public EfBaseDal(TContext context)
        {
            _context = context;
        }

        public void Ekle(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
        }

        public TEntity Getir(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().FirstOrDefault(filter);
        }

        public void Guncelle(TEntity entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
        }

        public IEnumerable<TEntity> HepsiniGetir(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? _context.Set<TEntity>()
                : _context.Set<TEntity>().Where(filter);
        }

        public void KaliciSil(Expression<Func<TEntity, bool>> filter)
        {
            var Entity = _context.Set<TEntity>().FirstOrDefault(filter);
            var deletedEntity = _context.Entry(Entity);
            deletedEntity.State = EntityState.Deleted;
        }

        public void Sil(Expression<Func<TEntity, bool>> filter)
        {
            var deletedEntity = _context.Set<TEntity>().FirstOrDefault(filter);
            var propertie = deletedEntity.GetType().GetProperty("AktifMi");
            propertie.SetValue(deletedEntity, true);
        }
    }
}
