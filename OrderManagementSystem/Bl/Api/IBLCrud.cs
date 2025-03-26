
namespace Bl.Api
{
    public interface ICrud<T>
    {
        Task<List<T>> GetAll();
    }
}
