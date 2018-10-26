using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomAmenities
    {
        [ForeignKey ("Room")]
        [Required]
        [Display(Name = "Room Type")]
        public int RoomID { get; set; }
        [Required]
        [ForeignKey ("Amenities")]
        [Display(Name = "Amenity")]
        public int AmenitiesID { get; set; }

        public Amenities Amenity { get; set; }
        public Room Room { get; set; }
    }
}
