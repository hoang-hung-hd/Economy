using System.ComponentModel.DataAnnotations;

namespace Web_Client.Models
{
    public class Brand
    {
        public int BrandId { set; get; }
        [Required]
        public string BrandName { set; get; }
    }
}
