using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRoom>().HasKey(
                ce => new { ce.HotelID, ce.RoomNumber }
                );

            modelBuilder.Entity<RoomAmenities>().HasKey(
                ce => new { ce.AmenitiesID, ce.RoomID }
                );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "Async Seattle",
                    Address = "12 Async Way, Seattle, WA 91234",
                    Phone = "206-123-1234"
                },
                new Hotel
                {
                    ID = 2,
                    Name = "Async NYC",
                    Address = "12 Async Way, New York City, NY 91234",
                    Phone = "555-123-1234"
                },
                new Hotel
                {
                    ID = 3,
                    Name = "Async LA",
                    Address = "12 Async Way, Los Angeles, CA 91234",
                    Phone = "555-123-1234"
                },
                new Hotel
                {
                    ID = 4,
                    Name = "Async Portland",
                    Address = "12 Async Way, Portland, OR 91234",
                    Phone = "555-123-1234"
                },
                new Hotel
                {
                    ID = 4,
                    Name = "Async Honolulu",
                    Address = "12 Async Way, Honolulu, HI 91234",
                    Phone = "555-123-1234"
                }
                );

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    ID = 1,
                    Name = "Sleeping Orca",
                    Layout = Layout.OneBedroom
                },
                new Room
                {
                    ID = 2,
                    Name = "Snoring Grizzly",
                    Layout = Layout.Studio
                },
                new Room
                {
                    ID = 3,
                    Name = "Snozing Dolphin",
                    Layout = Layout.TwoBedroom
                },
                new Room
                {
                    ID = 4,
                    Name = "Lazy Sloth",
                    Layout = Layout.OneBedroom
                },
                new Room
                {
                    ID = 5,
                    Name = "Sleepy Panda",
                    Layout = Layout.TwoBedroom
                },
                new Room
                {
                    ID = 6,
                    Name = "Yawning Peacock",
                    Layout = Layout.Studio
                }

                );

            modelBuilder.Entity<Room>().HasData(
                new Amenities
                {
                    ID = 1,
                    Name = "Coffee Machine"
                },
                new Amenities
                {
                    ID = 2,
                    Name = "Flat Screen TV"
                },
                new Amenities
                {
                    ID = 3,
                    Name = "Hot Tub"
                },
                new Amenities
                {
                    ID = 4,
                    Name = "A/C"
                },
                new Amenities
                {
                    ID = 5,
                    Name = "Toaster"
                }

                );
        }

        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
    }
}
