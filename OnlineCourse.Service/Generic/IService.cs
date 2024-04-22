namespace OnlineCourse.Service;

public interface IService<T> where T : class
{
    Task<T> GetByIdAsync(string url);
    Task<List<T>> GetAllAsync(string url);


}
