using CoureProject.Interfaces.Base;

namespace CoureProject.Interfaces;

public interface IRepository<T> where T : class, IEntity
{
    IEnumerable<T> GetAll();
    
    T? GetByID(int id);

    int Count();

    int Add(T item);

    bool Update(T item);

    bool Delete(T item);

}
