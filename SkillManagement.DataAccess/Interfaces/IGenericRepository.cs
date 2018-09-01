using SkillManagement.DataAccess.Entities;
using System.Collections.Generic;

namespace SkillManagement.DataAccess.Interfaces
{
    public interface IGenericRepository<TEntity, TId> where TEntity : IEntity<TId> //class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long Id);
        
        int Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

    }
}
