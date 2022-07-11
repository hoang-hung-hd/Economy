using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
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
