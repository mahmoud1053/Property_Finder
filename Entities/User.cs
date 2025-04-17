using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? National_Id { get; set; }
        public string? Phone {  get; set; }
        public string? Email { get; set; }      // New Email Property
        public string? Password { get; set; }  // New Password Property
        public ICollection<Residence>? Residences { get; set; } 

        public ICollection<Booking>? Booking { get; set; }

    }
}
