using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalService.Business.Repositories.Abstracts
{
    public interface IRepository<TEntity, TKey>
        where TKey : IEquatable<TKey>
        where TEntity : class
    {
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null);
        //Task<IQueryable<TEntity>> GetAsnyc(Expression<Func<TEntity, bool>> predicate = null);
        TEntity GetById(TKey id);
        int Insert(TEntity entity, bool isSaveLater = false);
        int Update(TEntity entity, bool isSaveLater = false);
        int Delete(TEntity entity, bool isSaveLater = false);
        int Save();
    }
}