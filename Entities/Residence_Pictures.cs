using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class Residence_Pictures
    {
        [Required] 
        public string? Url { get; set; }

        [Required]
        [ForeignKey("Residence")]
        public int ResidenceId { get; set; }
        public Residence? Residence { get; set; }

    }
}
