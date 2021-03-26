namespace MenuServer.Repositories
{
    public interface IDataRepository<T> where T : class
    {
        void Add(T entity);
        
        void Update(T entity);
        
        void Delete(T entity);
        
        T Save(T entity);
    }
}
