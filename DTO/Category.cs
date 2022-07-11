using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Category
    {
        public int CategoryId { set; get; }

        [Required]
        public string CategoryName { set; get; }

    }
}
