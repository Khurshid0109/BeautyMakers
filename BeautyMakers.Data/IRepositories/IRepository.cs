
namespace BeautyMakers.Data.IRepositories;
public interface IRepository<TEntity>
{
    Task<bool> DeleteAsync(long id);
    IQueryable<TEntity> SelectAll();
    Task<TEntity> SelectByIdAsync(long id);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> InsertAsync(TEntity entity);
}
