using System.ComponentModel.DataAnnotations;

namespace Web_Client.Models
{
    public class Product
    {
        public int ProductId { set; get; }
        [Required(ErrorMessage = "Name is required")]
        public string ProductName { set; get; }
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { set; get; }

        [Required(ErrorMessage = "Brand is required")]
        public int BrandId { set; get; }

        [Required(ErrorMessage = "Price is required")]
        public double ProductPrice { set; get; }
    }
}
