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
    }
}
