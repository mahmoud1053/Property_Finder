using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class Contract
    {
        public int Contract_Id { get; set; }
        public string? Terms { get; set; }
        public string? Start_Date { get; set; }
        public string? End_Date { get; set; }

        public ICollection<Booking>? Booking { get; set; }
    }
}
