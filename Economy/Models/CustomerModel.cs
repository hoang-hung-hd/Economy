using System.ComponentModel.DataAnnotations;

namespace Economy.Models
{
    public class CustomerModel
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage ="Customer name is required")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Customer phone is required")]
        public string CustomerPhone { get; set; }

        [Required(ErrorMessage = "Customer email is required")]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "Customer address is required")]
        public string CustomerAddress { set; get; }

        public List<BillModel> Bills { set; get; }
    }
}
