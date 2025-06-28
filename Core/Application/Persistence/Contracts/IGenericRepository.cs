namespace Application.Persistence.Contracts;

public interface IGenericRepository<T>  where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>>  GetAllAsync();
    Task<T>  CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<bool> CheckIfExists(int id);
}