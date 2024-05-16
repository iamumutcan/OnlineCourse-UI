namespace OnlineCourse.Service;

public interface IService<T> where T : class
{
    Task<T> GetAsync(string url);
    Task<T> GetAsync(string url, string authToken);
    Task<List<T>> GetAllAsync(string url);
    Task<T> PostAsync(string url, T data);
    Task<T> PostAsync(string url, T data, string authToken);


}
