using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayeredDbConsole.Data.Repositories;

namespace LayeredDbConsole.Models
{
    public class Customer: IBaseEntity
    {
        [Key]
        public Guid RegistrationNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        public HashSet<Lease> Leases { get; set; } = new HashSet<Lease>();
    }
}
