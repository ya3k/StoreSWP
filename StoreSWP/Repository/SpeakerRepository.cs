using Microsoft.EntityFrameworkCore;
using StoreSWP.Data;
using StoreSWP.Interface;
using StoreSWP.Models;
using StoreSWP.ViewsModel;

namespace StoreSWP.Repository
{
    //thuc hien cac viec lien quan database
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly ApplicationDbContext _context;
        private IEnumerable<Speaker> _speakerList = new List<Speaker>();
        public SpeakerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //get list speaker
        public async Task<IEnumerable<Speaker>> GetAllSpeaker()
        {
            _speakerList = await _context.Speakers.Include(b => b.Brand).ToListAsync();
            return _speakerList;
        }


        //get by id
        public async Task<Speaker> GetSpeakerById(int id)
        {
            return await _context.Speakers.Include(b => b.Brand).FirstOrDefaultAsync(s => s.Id == id);
        }

        //get by name
        public async Task<IEnumerable<Speaker>> GetSpeakerByName(string name)
        {
            _speakerList = await _context.Speakers.Where(s => s.Name.Contains(name)).ToListAsync();
            return _speakerList;
        }

        //bi loi
        public async Task<IEnumerable<Speaker>> GetSpeakerByBrand(int brandId)
        {
            _speakerList = await _context.Speakers.Include(b => b.Brand).Where(s => s.Brand.Id == brandId).ToListAsync();
            return _speakerList;
        }

        public IEnumerable<Speaker> SortSpeakerByNameDesc()
        {

            return _speakerList.OrderByDescending(s => s.Name);
        }
        public IEnumerable<Speaker> SortSpeakerByNameIcs()
        {
            return _speakerList.OrderBy(s => s.Name);

        }

        //sort z-a
        //public async Task<IEnumerable<Speaker>> SortSpeakerByNameDesc()
        //{
        //    return await _context.Speakers.Include(b => b.Brand).OrderByDescending(s => s.Name).ToListAsync();
        //}

        ////sort a-z
        //public async Task<IEnumerable<Speaker>> SortSpeakerByNameIcs()
        //{
        //    return await _context.Speakers.Include(b => b.Brand).OrderBy(s => s.Name).ToListAsync();
        //}

        //public async Task<IEnumerable<Speaker>> SortByPriceMinToMax(double minPrice, double maxPrice)
        //{
        //    //return await _context.Speakers.Include(b => b.Brand)
        //    //     .Where(s => s.Price >= minPrice && s.Price <= maxPrice).ToListAsync();
        //    IEnumerable<Speaker> speakers = await GetAllSpeaker();
        //    StoreViewModel storeVM = new StoreViewModel();


        //    if (minPrice == null || minPrice < 0)
        //    {
        //        minPrice = 0;
        //    }
        //    if (maxPrice == null || maxPrice < minPrice || maxPrice < 0)
        //    {
        //        maxPrice = _context.Speakers.Include(b => b.Brand).Max(s => s.Price);
        //    }
        //    if (minPrice >= 0)
        //    {
        //        speakers = _context.Speakers.Include(b => b.Brand).Where(s => s.Price >= minPrice);
        //    }
        //    if (maxPrice >= 0 && maxPrice > minPrice)
        //    {
        //        speakers = _context.Speakers.Include(b => b.Brand).Where(s => s.Price <= maxPrice);
        //    }

        //    //speakers = _context.Speakers.Include(b => b.Brand).OrderBy(s => s.Price).ToList();
        //    speakers = speakers.Where(s => s.Price >= minPrice && s.Price <= maxPrice).OrderBy(s => s.Price);

        //    return speakers;

        //}

        //public async Task<IEnumerable<Speaker>> SortSpeakerByPriceIcs()
        //{
        //    return await _context.Speakers.Include(b => b.Brand).OrderBy(s => s.Price).ToListAsync();
        //}

        //public async Task<IEnumerable<Speaker>> SortSpeakerByPriceDesc()
        //{
        //    return await _context.Speakers.Include(b => b.Brand).OrderByDescending(s => s.Price).ToListAsync();
        //}
    }
}
