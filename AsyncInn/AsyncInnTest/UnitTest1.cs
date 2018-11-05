using AsyncInn.Data;
using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace AsyncInnTest
{
    public class UnitTest1
    {
        /// <summary>
        /// Testing to get hotel name
        /// </summary>
        [Fact]
        public void CanGetHotelName()
        {
            //Arrange
            Hotel hotel = new Hotel();
            //Act
            hotel.Name = "Async Seattle";
            //Assert
            Assert.Equal("Async Seattle", hotel.Name);
        }

        /// <summary>
        /// Testing to set hotel name
        /// </summary>
        [Fact]
        public void CanSetHotelName()
        {
            //Arrange
            Hotel hotel = new Hotel();
            //Act
            hotel.Name = "Async Seattle";
            hotel.Name = "Async NYC";
            //Assert
            Assert.Equal("Async NYC", hotel.Name);
        }

        /// <summary>
        /// Testing to get room name
        /// </summary>
        [Fact]
        public void CanGetRoomName()
        {
            Room room = new Room();
            room.Name = "Snoring Koala";
            Assert.Equal("Snoring Koala", room.Name);
        }

        /// <summary>
        /// Testing to set room name
        /// </summary>
        [Fact]
        public void CanSetRoomName()
        {
            Room room = new Room();
            room.Name = "Snoring Koala";
            room.Name = "Sleeping Lion";
            Assert.Equal("Sleeping Lion", room.Name);
        }

        /// <summary>
        /// Testing to get amenity name
        /// </summary>
        [Fact]
        public void CanGetAmenityName()
        {
            Amenities amenity = new Amenities();
            amenity.Name = "Coffee Machine";
            Assert.Equal("Coffee Machine", amenity.Name);
        }

        /// <summary>
        /// Testing to set amenity name
        /// </summary>
        [Fact]
        public void CanSetAmenityName()
        {
            Amenities amenity = new Amenities();
            amenity.Name = "Coffee Machine";
            amenity.Name = "A/C";
            Assert.Equal("A/C", amenity.Name);
        }

        /// <summary>
        /// Testing to get hotel room number
        /// </summary>
        [Fact]
        public void CanGetHotelRoomNumber()
        {
            HotelRoom hr = new HotelRoom();
            hr.RoomNumber = 101;
            Assert.Equal(101, hr.RoomNumber);
        }

        /// <summary>
        /// Testing to set hotel room number
        /// </summary>
        [Fact]
        public void CanSetHotelRoomNumber()
        {
            HotelRoom hr = new HotelRoom();
            hr.RoomNumber = 101;
            hr.RoomNumber = 121;
            Assert.Equal(121, hr.RoomNumber);
        }

        /// <summary>
        /// Testing Hotel Create
        /// </summary>
        [Fact]
        public async void CanCreateHotelOnDB()
        {
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("CreateHotel")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //Arrange
                Hotel hotel = new Hotel();
                hotel.Name = "Async Seattle";
                context.Hotels.Add(hotel);
                context.SaveChanges();

                //Act
                var newHotel = await context.Hotels.FirstOrDefaultAsync(x => x.Name == hotel.Name);

                //Asser
                Assert.Equal(hotel.Name, newHotel.Name);
            }
        }

        /// <summary>
        /// Testing updating hotel
        /// </summary>
        [Fact]
        public async void CanUpdateHotelOnDB()
        {
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("UpdateHotel")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //Arrange
                Hotel hotel = new Hotel();
                hotel.Name = "Async Seattle";
                context.Hotels.Add(hotel);
                context.SaveChanges();

                //Act
                var newHotel = await context.Hotels.FirstOrDefaultAsync(x => x.Name == hotel.Name);

                newHotel.Name = "Async NYC";
                int id = newHotel.ID;

                var updatedHotel = await context.Hotels.FirstOrDefaultAsync(x => x.ID == id);

                //Assert 
                Assert.Equal("Async NYC", updatedHotel.Name);
            }
        }
        
        /// <summary>
        /// Testing deleting hotel
        /// </summary>
        [Fact]
        public async void CanDeleteHotelOnDB()
        {
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("DeleteHotel")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //Arrange - create hotel and assign values
                Hotel hotel = new Hotel();
                hotel.Name = "Async Seattle";
                context.Hotels.Add(hotel);
                context.SaveChanges();

                //Act
                var newHotel = await context.Hotels.FirstOrDefaultAsync(x => x.Name == hotel.Name);
                int id = newHotel.ID;

                context.Hotels.Remove(newHotel);
                await context.SaveChangesAsync();

                var deletedHotel = await context.Hotels.FirstOrDefaultAsync(x => x.ID == id);

                //Assert - grab from db and assert entry
                Assert.Null(deletedHotel);
            }
        }

        /// <summary>
        /// Testing create and read room
        /// </summary>
        [Fact]
        public async void CanCreateRoomDB()
        {
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("CreateRoom")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //Arrange
                Room room = new Room();
                room.Name = "Orca";
                context.Rooms.Add(room);
                context.SaveChanges();

                //Act
                var newRoom = await context.Rooms.FirstOrDefaultAsync(x => x.Name == room.Name);

                //Assert
                Assert.Equal(newRoom.Name, room.Name);
            }
        }

        /// <summary>
        /// Testing updating room
        /// </summary>
        [Fact]
        public async void CanUpdateRoomDB()
        {
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("UpdateRoom")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //Arrange
                Room room = new Room();
                room.Name = "Orca";
                context.Rooms.Add(room);
                context.SaveChanges();

                //Act
                var newRoom = await context.Rooms.FirstOrDefaultAsync(x => x.Name == room.Name);

                newRoom.Name = "Dolphin";
                int id = newRoom.ID;

                var updatedRoom = await context.Rooms.FirstOrDefaultAsync(x => x.ID == id);

                //Assert
                Assert.Equal("Dolphin", updatedRoom.Name);
            }
        }

        /// <summary>
        /// Testing deleting room
        /// </summary>
        [Fact]
        public async void CanDeleteRoomDB()
        {
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("DeleteRoom")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //Arrange
                Room room = new Room();
                room.Name = "Orca";
                context.Rooms.Add(room);
                context.SaveChanges();

                //Act
                var newRoom = await context.Rooms.FirstOrDefaultAsync(x => x.Name == room.Name);

                int id = newRoom.ID;

                context.Rooms.Remove(newRoom);
                await context.SaveChangesAsync();

                var deletedRoom = await context.Rooms.FirstOrDefaultAsync(x => x.ID == id);

                //Assert
                Assert.Null(deletedRoom);
            }
        }

        /// <summary>
        /// Testing creating a Hotel Room.
        /// </summary>
        [Fact]
        public async void CanCreateHotelRoomOnDB()
        {
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("CreateHotelRoom")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //Arrange
                Hotel hotel = new Hotel();
                hotel.Name = "Asyn Seattle";
                Room room = new Room();
                room.Name = "Orca";
                context.Add(hotel);
                context.Add(room);
                context.SaveChanges();

                //Act
                var newHotel = context.Hotels.FirstOrDefaultAsync(x => x.Name == hotel.Name);
                var newRoom = context.Rooms.FirstOrDefaultAsync(x => x.Name == room.Name);

                HotelRoom hr = new HotelRoom();
                hr.HotelID = newHotel.Id;
                hr.RoomID = newRoom.Id;
                hr.PetFriendly = true;
                context.HotelRooms.Add(hr);
                context.SaveChanges();

                var hotelroom = await context.HotelRooms.FirstOrDefaultAsync(x => x.HotelID == hr.HotelID);

                //Assert
                Assert.Equal(hotelroom.RoomID, hr.RoomID);
            }
        }

    }
}
