namespace Image_Processor.Data.Repositories
{
    interface IRepository<T, Id>
    {
        Task<List<T>> GetAll(string TextSearch);
        Task<T> GetById(Id ID);
        Task Insert(T Object);
        void Update(T Object);
        Task Delete(Id ID);
        Task SaveChangesAsync();
        void SaveChanges();
        Task<bool> IsExists(Id ID);
    }
}
