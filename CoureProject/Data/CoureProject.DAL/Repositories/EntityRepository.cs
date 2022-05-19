using CoureProject.DAL.Context;
using CoureProject.Interfaces;
using CoureProject.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CoureProject.DAL.Repositories;

public class EntityRepository<T> : IRepositoryAsync<T> where T : class, IEntity
{
    protected readonly CoureProjectDB _db;
    private readonly ILogger<EntityRepository<T>> _logger;

    public EntityRepository(CoureProjectDB DB, ILogger<EntityRepository<T>> Logger)
    {
        _db = DB;
        _logger = Logger;
    }
    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancel = default)
    {
        var items = await _db
            .Set<T>()
            .ToListAsync(cancel)
            .ConfigureAwait(false);
        return items;
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        var item = await _db
            .Set<T>()
            .FirstOrDefaultAsync(o => o.id == id, cancel)
            .ConfigureAwait(false);
        return item;
    }
    public async Task<int> CountAsync(CancellationToken cancel = default)
    {
        var item = await _db
            .Set<T>()
            .CountAsync(cancel)
            .ConfigureAwait(false);
        return item;
    }

    public async Task<int> AddAsync(T item, CancellationToken cancel = default)
    {
        await _db.Set<T>().AddAsync(item, cancel).ConfigureAwait(false);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return item.id;
    }
    public async Task<bool> UpdateAsync(T item, CancellationToken cancel = default)
    {
        var db_item = await GetByIdAsync(item.id, cancel).ConfigureAwait(false);
        if (db_item is null)
        {
            return false;
        }
        _db.Entry(item).State = EntityState.Modified;
        return await _db.SaveChangesAsync(cancel) > 0;
    }

    public async Task<T?> DeleteAsync(T item, CancellationToken cancel = default)
    {
        if (!await _db.Set<T>().AnyAsync(o => o.id == item.id, cancel).ConfigureAwait(false))
        {
            return null;
        }
        _db.Entry(item).State = EntityState.Deleted;
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return item;
    }
}
