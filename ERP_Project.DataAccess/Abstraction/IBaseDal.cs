using ERP_Project.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ERP_Project.DataAccess.Abstraction
{
    public interface IBaseDal<TEntity> where TEntity : class, IEntity, new()
    {
        IEnumerable<TEntity> HepsiniGetir(Expression<Func<TEntity, bool>> filter = null);
        TEntity Getir(Expression<Func<TEntity, bool>> filter);
        void Ekle(TEntity entity);
        void Guncelle(TEntity entity);
        void Sil(Expression<Func<TEntity, bool>> filter);
        void KaliciSil(Expression<Func<TEntity, bool>> filter);
    }
}
