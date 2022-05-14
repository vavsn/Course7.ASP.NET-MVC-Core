using CoureProject.DAL.Context;
using CoureProject.Interfaces;
using CoureProject.Interfaces.Base;
using Microsoft.Extensions.Logging;

namespace CoureProject.DAL.Repositories;

public class EntityRepository<T> : IRepository<T> where T : class, IEntity
{
    private readonly CoureProjectDB _db;
    private readonly ILogger<EntityRepository<T>> _logger;

    public EntityRepository(CoureProjectDB DB, ILogger<EntityRepository<T>> Logger)
    {
        _db = DB;
        _logger = Logger;
    }

    public int Add(T item)
    {
        _db.Set<T>().Add(item);
        _db.SaveChanges();
        return item.Id;
    }

    public int Count()
    {
        var item = _db.Set<T>().Count();
        return item;
    }

    public bool Delete(T item)
    {
        if (!_db.Set<T>().Any(o => o.Id == item.Id))
        {
            return false;
        }
        _db.Set<T>().Remove(item);
        _db.SaveChanges();
        return true;
    }

    public IEnumerable<T> GetAll()
    {
        var items = _db.Set<T>().ToList();
        return items;
    }

    public T? GetByID(int id)
    {
        var item = _db.Set<T>().FirstOrDefault(o => o.Id == id);
        return item;
    }

    public bool Update(T item)
    {
        if (!_db.Set<T>().Any(o => o.Id == item.Id))
        {
            return false;
        }
        _db.Set<T>().Update(item);
        _db.SaveChanges();
        return true;
    }
}

