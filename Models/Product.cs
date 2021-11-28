using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
        public int CategoryId { get; set; }
        public int StoreId { get; set; }

        [ForeignKey("CategoryId")]
        [JsonIgnore]
        public Category Category { get; set; }

        [ForeignKey("StoreId")]
        [JsonIgnore]
        public Store StoreData { get; set; }
    }
}
