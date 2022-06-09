namespace Netpower.Traning._2022.Repositories
{
     public interface IBaseRepository<T> where T : class
     {
          public Task<List<T>> Get(int limit = 20, int page = 1);
          public ValueTask<T> Get(Guid ID);
          public Task<T> Insert(T entity);
          public Task<int> Update(T entity);
          public Task<int> Delete(T entity);
     }
}
