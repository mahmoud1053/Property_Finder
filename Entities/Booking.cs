using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class Booking
    {
        //Contract Table
        public int Contract_Id { get; set; }
        public Contract? Contract { get; set; }

        //Residence Table        
        public int ResidenceId { get; set; }
        public Residence? Residence { get; set; }

        //User Table        
        public int UserId { get; set; }
        public User? User { get; set; }


        public DateTime BookingDate { get; set; }
    }
}
