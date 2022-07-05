using System.ComponentModel.DataAnnotations;

namespace Economy.Models
{
    public class BrandModel
    {
        [Key]
        public int BrandId { set; get; }
        [Required]
        public string BrandName { set; get; }
        public List<ProductModel> Products { get; set; }

    }
}
