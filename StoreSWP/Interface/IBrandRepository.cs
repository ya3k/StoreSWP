using StoreSWP.Models;

namespace StoreSWP.Interface
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> GetAllBrand();
        Task<Brand> GetBrandById(int id);


    }
}
