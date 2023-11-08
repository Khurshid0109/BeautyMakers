using BeautyMakers.Data.Data;
using BeautyMakers.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using BeautyMakers.Data.IRepositories;

namespace BeautyMakers.Data.Repositories;
public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly DataContext _context;
    private readonly DbSet<TEntity> _dbSet;
    public Repository(DataContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var res = await _dbSet.FirstOrDefaultAsync(r => r.Id == id);
        _dbSet.Remove(res);

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        var res = await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return res.Entity;
    }

    public IQueryable<TEntity> SelectAll() =>
        _dbSet;


    public async Task<TEntity> SelectByIdAsync(long id)
    {
        var res = await _dbSet.FirstOrDefaultAsync(r => r.Id == id);
        return res;
    }
    

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var res = _dbSet.Update(entity);
        await _context.SaveChangesAsync();

        return res.Entity;
    }
}
