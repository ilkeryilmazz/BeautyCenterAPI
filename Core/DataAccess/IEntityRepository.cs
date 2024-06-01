using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;


namespace Core.DataAccess
{
   public interface IEntityRepository<TEntity> where TEntity:class,IEntity,new()
    {
        Task<List<TEntity>> GetAll(Expression<Func<TEntity,bool>> filter=null);
        Task<TEntity> Get(Expression<Func<TEntity,bool>> filter);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(TEntity entity);
        Task<List<TEntity>> AddMultiple(List<TEntity> entity);
        Task<List<TEntity>> UpdateMultiple(List<TEntity> entity);
    }
}
