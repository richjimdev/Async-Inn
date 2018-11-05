using AsyncInn.Models;
using System;
using Xunit;

namespace AsyncInnTest
{
    public class UnitTest1
    {
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

        [Fact]
        public void CanGetRoomName()
        {
            Room room = new Room();
            room.Name = "Snoring Koala";
            Assert.Equal("Snoring Koala", room.Name);
        }

        //Test set Room Name
        [Fact]
        public void CanSetRoomName()
        {
            Room room = new Room();
            room.Name = "Snoring Koala";
            room.Name = "Sleeping Lion";
            Assert.Equal("Sleeping Lion", room.Name);
        }

        [Fact]
        public void CanGetAmenityName()
        {
            Amenities amenity = new Amenities();
            amenity.Name = "Coffee Machine";
            Assert.Equal("Coffee Machine", amenity.Name);
        }

        //Test SetAmenityName
        [Fact]
        public void CanSetAmenityName()
        {
            Amenities amenity = new Amenities();
            amenity.Name = "Coffee Machine";
            amenity.Name = "A/C";
            Assert.Equal("A/C", amenity.Name);
        }

        [Fact]
        public void CanGetHotelRoomNumber()
        {
            HotelRoom hr = new HotelRoom();
            hr.RoomNumber = 101;
            Assert.Equal(101, hr.RoomNumber);
        }

        [Fact]
        public void CanSetHotelRoomNumber()
        {
            HotelRoom hr = new HotelRoom();
            hr.RoomNumber = 101;
            hr.RoomNumber = 121;
            Assert.Equal(121, hr.RoomNumber);
        }
    }
}
