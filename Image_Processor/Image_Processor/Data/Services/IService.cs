namespace Image_Processor.Data.Services
{
    public interface IService<T, Id,R>
    {
        Task<R> GetAll(string TextSearch);
        Task<R> GetById(Id ID);
        Task Insert(T Object);
        void Update(T Object);
        Task Delete(Id ID);
        Task SaveChangesAsync();
        void SaveChanges();
        Task<R> IsExists(Id ID);
    }
}
