namespace UTBDesktopApp.Services
{
    public interface IDbService
    {
        Task<List<T>> GetAll<T>(string endpoint) where T : class;
        Task<T> Get<T>(string endpoint, int id) where T : class;
        Task<bool> Add<T>(string endpoint, T s);
    }
}
