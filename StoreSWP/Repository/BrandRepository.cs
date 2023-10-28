using Microsoft.EntityFrameworkCore;
using StoreSWP.Data;
using StoreSWP.Interface;
using StoreSWP.Models;

namespace StoreSWP.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _context;
        public BrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Brand> GetAllBrand()
        {
            return _context.Brands.ToList();
        }

        public async Task<Brand> GetBrandById(int id)
        {
            return await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
