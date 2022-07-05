using System.ComponentModel.DataAnnotations;

namespace Economy.Models
{
    public class StoreModel
    {
        [Key]
        public int StoreId { set; get; }
        [Required(ErrorMessage ="Store name is required")]
        public string StoreName { set; get; }

        [Required(ErrorMessage = "Store phone is required")]
        public string StorePhone { set; get; }

        [Required(ErrorMessage = "Store email is required")]
        [EmailAddress]
        public string StoreEmail { set; get; }

        [Required(ErrorMessage = "Store address is required")]
        public string StoreAddress { set; get; }

        [Required(ErrorMessage = "Store zip-code is required")]
        public string StoreZipCode { set; get; }

        public List<StaffModel> Staffs { set; get; }
        public List<BillModel> Bills { set; get; }
    }
}
