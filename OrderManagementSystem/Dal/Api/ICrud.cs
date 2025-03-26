

namespace Dal.Api
{
    public interface ICrud<T>
    {
       Task<List<T>> GetAll();
    }
}
