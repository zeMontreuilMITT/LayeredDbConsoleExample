using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredDbConsole.Models
{
    public class Lease
    {
        public Guid Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public Vehicle Vehicle { get; set; }
        [Required]
        public Guid VehicleRegistrationNumber { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public Guid CustomerRegistrationNumber { get; set; }
    }
}
