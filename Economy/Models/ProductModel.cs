using System.ComponentModel.DataAnnotations;

namespace Economy.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductId { set; get; }
        [Required(ErrorMessage ="Name is required")]
        public string ProductName { set; get; }
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { set; get; }

        [Required(ErrorMessage = "Brand is required")]
        public int BrandId { set; get; }

        [Required(ErrorMessage = "Price is required")]
        public double ProductPrice { set; get; }

        public CategoryModel Category { get; set; }
        public BrandModel Brand { get; set; }
    }
}
