using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using car_rental.Data;

namespace car_rental.Models
{
    [Table("Car")]
    public class Car
    {
        [Required]
        [Key]
        public long Id { set; get; }
        [Required]
        public string Brand { set; get; }
        [Required]
        public string Model { set; get; }
        [Required]
        public string Location { set; get; }
        [Required]
        public string Transmission { set; get; }
        
       
        [Required]
        [Range(1455,2020,ErrorMessage = "Wrong year, enter a valid one (1455 - 2020)")]
        public int Year { set; get; }

        
        /// <summary>
        /// Email of the student that added the car
        /// </summary>
        public string Name_Customer { set; get; }
        /// <summary>
        /// If it's booked or not
        /// </summary>
        public long State { set; get; }
    }
}
