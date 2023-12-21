using LayeredDbConsole.Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredDbConsole.Models
{
    public class Vehicle: IBaseEntity
    {
        [Key]
        public Guid RegistrationNumber {  get; set; }

        [Required]
        [MaxLength(7), MinLength(3)]
        public string LicenceNumber { get; set; }

        public Colour Colour { get; set; }

        [Required]
        [MinLength(3), MaxLength(100)]
        public string Model { get; set; }

        public Lease? Lease { get; set; }
    }

    public enum Colour
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet,
        White,
        Black,
        Grey
    }
}
