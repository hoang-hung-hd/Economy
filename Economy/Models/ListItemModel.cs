using System.ComponentModel.DataAnnotations;

namespace Economy.Models
{
    public class ListItemModel
    {
        [Key]
        public int ListItemId { set; get; }

        [Required(ErrorMessage ="Bill id is required")]
        public int BillId { set; get; }
        [Required(ErrorMessage = "Product id is required")]
        public int ProductId { set; get; }


        [Required(ErrorMessage = "Item quantity is required")]
        public int ItemQuantity { set; get; }

        [Required(ErrorMessage = "Item price is required")]
        public double ItemPrice { set; get; }

        public double DiscountPercent { set; get; } = 0;

        public BillModel Bill { set; get; }
        public List<ProductModel> Products { set; get; }
    }
}
