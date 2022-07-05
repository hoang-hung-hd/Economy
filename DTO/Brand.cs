using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Brand
    {
        public int BrandId { set; get; }
        [Required]
        public string BrandName { set; get; }
    }
}
