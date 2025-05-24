

namespace DAL.Api
{
    public interface ICrud<T>
    {
        Task<List<T>> GetAll();
        Task<T> Create(T t);
        Task<T> Update(T t);
        Task<T> Delete(T t);
    }
}
