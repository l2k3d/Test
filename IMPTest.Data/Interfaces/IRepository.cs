namespace IMPTest.Data.Interfaces;

public interface IRepository<T,K>
{
    Task<List<T>> GetAll();
    Task<T> GetById(K id);
    Task<int> Create(T entity);
    Task<int> Update(T entity);
    Task<int> Delete(T entity);
}
