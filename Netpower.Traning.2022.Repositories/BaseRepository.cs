using Microsoft.EntityFrameworkCore;

namespace Netpower.Traning._2022.Repositories
{
     public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
     {
          private readonly DatabaseContext _dbContext;
          private readonly DbSet<T> _table;

          public BaseRepository(DatabaseContext context)
          {
               _dbContext = context;
               _table = _dbContext.Set<T>();
          }

          public Task<List<T>> Get(int limit, int page)
          {
               if (limit == 0) limit = 20;
               if (page == 0) page = 1;
               
               return _table.Skip((page - 1) * limit).Take(limit).ToListAsync();
          }

          public ValueTask<T> Get(Guid ID)
          {
               return _table.FindAsync(ID);
          }

          public async Task<T> Insert(T entity)
          {
               await _table.AddAsync(entity);
               await _dbContext.SaveChangesAsync();

               return entity;
          }

          public Task<int> Update(T entity)
          {
               _table.Update(entity);

               return _dbContext.SaveChangesAsync();
          }

          public Task<int> Delete(T entity)
          {
               _dbContext.Remove(entity);
               return _dbContext.SaveChangesAsync();
          }
     }
}
