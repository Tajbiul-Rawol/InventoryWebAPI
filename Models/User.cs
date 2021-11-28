using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string BloodGroup { get; set; }
        public string Religion { get; set; }
        public int UserLoginID { get; set; }
        public string Gender { get; set; }
    }
}
