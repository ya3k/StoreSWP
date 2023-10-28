using StoreSWP.Models;

namespace StoreSWP.ViewsModel
{
    public class StoreViewModel
    {
        public IEnumerable<Speaker> Speakers { get; set; }
        public IEnumerable<Brand> Brands { get; set; }

    }
}
