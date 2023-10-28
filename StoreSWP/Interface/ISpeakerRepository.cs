using StoreSWP.Models;
using StoreSWP.ViewsModel;

namespace StoreSWP.Interface
{
    public interface ISpeakerRepository
    {

        Task<IEnumerable<Speaker>> GetAllSpeaker();
        Task<Speaker> GetSpeakerById(int id);
        Task<IEnumerable<Speaker>> GetSpeakerByName(string name);
        Task<IEnumerable<Speaker>> GetSpeakerByBrand(int brandId);

        IEnumerable<Speaker> SortSpeakerByNameDesc();
        IEnumerable<Speaker> SortSpeakerByNameIcs();
        //Task<IEnumerable<Speaker>> SortSpeakerByNameDesc();
        //Task<IEnumerable<Speaker>> SortSpeakerByNameIcs();
        //Task<IEnumerable<Speaker>> SortByPriceMinToMax(double minPrice, double maxPrice);
        //Task<IEnumerable<Speaker>> SortSpeakerByPriceIcs();
        //Task<IEnumerable<Speaker>> SortSpeakerByPriceDesc();
    }
}
