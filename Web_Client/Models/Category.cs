using System.ComponentModel.DataAnnotations;

namespace Web_Client.Models
{
    public class Category
    {
        public int CategoryId { set; get; }

        [Required]
        public string CategoryName { set; get; }
    }
}
