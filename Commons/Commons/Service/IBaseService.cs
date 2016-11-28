using Commons.Model;

namespace Commons.Service
{
    public interface IBaseService<T> where T : Entity
    {
        bool Add(T entity);
        bool Delete(T entity);
        bool Delete(string id);
        bool Edit(T entity);
    }
}