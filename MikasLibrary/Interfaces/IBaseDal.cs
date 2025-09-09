namespace MikasLibrary.Interfaces
{
    public interface IBaseDal<T> where T : class
    {
        void Add(T entity);
        Task<List<T>> GetAllAsync();
//        Task<T?> GetByIdAsync(Guid id);
        //void Update(T entity);
        Task SaveChangesAsync();
    }
}
