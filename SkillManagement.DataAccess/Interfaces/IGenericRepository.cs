using System.Collections.Generic;

namespace SkillManagement.DataAccess.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long Id);
        int Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

    }
}
