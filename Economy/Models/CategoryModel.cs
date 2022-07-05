using System.ComponentModel.DataAnnotations;

namespace Economy.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { set; get; }

        [Required]
        public string CategoryName { set; get; }

        public List<ProductModel> Products { get; set; }
    }
}
