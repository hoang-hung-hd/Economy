using System.ComponentModel.DataAnnotations;

namespace Economy.Models
{
    public class StaffModel
    {
        [Key]
        public int StaffId { set; get; }

        [Required(ErrorMessage ="Staff name is required")]
        public string StaffName { set; get; }

        [Required(ErrorMessage = "Staff email is required")]
        [EmailAddress]
        public string StaffEmail { set; get; }

        [Required(ErrorMessage = "Staff phone is required")]
        public string StaffPhone { set; get; }

        [Required(ErrorMessage = "Staff name is required")]
        public string StaffActive { set; get; }

        [Required(ErrorMessage = "Staff store id is required")]
        public int StaffInStoreId { set; get; }

        public StoreModel Store { set; get; }
        public List<BillModel> Bills { set; get; }

    }
}
