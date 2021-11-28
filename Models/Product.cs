using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string ProductDetail { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string ProductType { get; set; }
        [Required]
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public Category Category { get; set; }
    }
}
