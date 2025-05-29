
namespace BL.Api
{
    public interface IBLCrud<T>
    {
        Task<List<T>> GetAll();
     
      

    }
}               
