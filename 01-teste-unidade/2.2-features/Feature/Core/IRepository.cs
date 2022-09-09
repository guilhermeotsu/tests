using System.Collections.Generic;

namespace Feature.Core
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
