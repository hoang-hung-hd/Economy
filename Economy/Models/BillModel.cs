using System.ComponentModel.DataAnnotations;

namespace Economy.Models
{
    public class BillModel
    {
        [Key]
        public int BillId { get; set; }

        public int? CustomerId { set; get; }

        [Required(ErrorMessage = "Bill status is required")]
        public string? BillStatus { set; get; }

        [Required(ErrorMessage = "Bill created-day is required")]
        public DateTime BillCreateDate { get; set; }

        [Required(ErrorMessage = "Bill required-day is required")]
        public DateTime BillRequiredDate { set; get; }

        [Required(ErrorMessage = "Bill shipped-day is required")]
        public DateTime BillShippedDate { set; get; }
        public int? StoreId { get; set; }

        public int? StaffId { get; set; }

        public StaffModel Staff { get; set; }
        public StoreModel Store { get; set; }
        public CustomerModel Customer { set; get; }

        public List<ListItemModel> ListItems { set; get; }
    }
}
