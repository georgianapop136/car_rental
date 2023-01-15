using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace car_rental.Models
{
    [Table("Booking")]
    public class Booking
    {
        [Required]
        [Key]
        public long Id_Booking { set; get; }
        [DataType(DataType.Date)]
        public string Start_Booking { set; get; }
        [DataType(DataType.Date)]
        public string End_Booking { set; get; }
        public string Brand { set; get; }
        
        /// <summary>
        /// Student that reserved the car
        /// </summary>
        public string Customer { set; get; }
        public long Id_Car { set; get; }
    }
}
