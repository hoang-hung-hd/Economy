using System.ComponentModel.DataAnnotations;

namespace Economy.Models
{
    public class StockModel
    {
        [Key]
        public int StoreId { set; get; }
        [Key]
        public int ProductId { set; get; }
        public int QuantityInStock { set; get; }

        public StoreModel Store { get; set; }
        public ProductModel Product { get; set; }
    }
}
