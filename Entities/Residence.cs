using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class Residence
    {
        public int ResidenceId { get; set; }
        public int Num_Of_Rooms { get; set; }
        public string? Street { get; set; }
        public int Building_Num { get; set; }
        public int Apartment_Num { get; set; }
        public int Floor_Num { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }
        public double Rent_Fee { get; set; }
        public ICollection<Residence_Pictures>? Pictures { get; set; }
        public ICollection<Booking>? Booking { get; set; }
       

        // Foreign Key
        public int UserId { get; set; }

        // Navigation property back to the owner
        public User? User { get; set; }

    }
}
