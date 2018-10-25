using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomAmenities
    {
        [ForeignKey ("Room")]
        public int RoomID { get; set; }
        [ForeignKey ("Amenities")]
        public int AmenitiesID { get; set; }

        public Amenities Amenity { get; set; }
        public Room Room { get; set; }
    }
}
