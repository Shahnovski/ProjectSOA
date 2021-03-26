namespace MenuServer.Services
{
    public interface IDataService<T> where T : class
    {
        T GetById(int id);

        T Save(int id, T dto);

        void Delete(int id);

        bool EntityExists(int id);
    }
}
