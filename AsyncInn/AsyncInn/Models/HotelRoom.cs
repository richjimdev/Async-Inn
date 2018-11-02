using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        public int HotelID { get; set; }
        [Required]
        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }
        [Display(Name = "Room Type")]
        public int RoomID { get; set; }
        public decimal Rate { get; set; }
        [Display(Name = "Pet Friendly")]
        public bool PetFriendly { get; set; }

        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}
