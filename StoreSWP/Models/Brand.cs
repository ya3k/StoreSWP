using System.ComponentModel.DataAnnotations;

namespace StoreSWP.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
