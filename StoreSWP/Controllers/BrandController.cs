using Microsoft.AspNetCore.Mvc;
using StoreSWP.Data;
using StoreSWP.Interface;
using StoreSWP.Models;

namespace StoreSWP.Controllers
{
    public class BrandController : Controller
    {
        //private readonly ApplicationDbContext _context;
        //public BrandController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        private readonly IBrandRepository _brandRepository;
        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        //get all brand
        public IActionResult GetAllBrand()
        {
            IEnumerable<Brand> brands = _brandRepository.GetAllBrand();
            return View(brands);
        }

        //get detail brand 
        public async Task<IActionResult> DetailBrand(int id)
        {
            var brandwid = await _brandRepository.GetBrandById(id);
            return View(brandwid);
        }
    }
}
