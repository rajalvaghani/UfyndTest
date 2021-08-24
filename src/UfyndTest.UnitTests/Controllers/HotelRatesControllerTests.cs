using System;
using Microsoft.AspNetCore.Mvc;
using UfyndTest.Api.Controllers;
using UfyndTest.Api.Model;
using Xunit;

namespace UfyndTest.UnitTests.Controllers
{
    public class HotelRatesControllerTests
    {
        private readonly HotelRatesController _hotelRatesController;

        public HotelRatesControllerTests()
        {
            _hotelRatesController = new HotelRatesController();
        }

        [Fact]
        public void Get_WhenHotelRatesNotFound_ReturnsNotFoundResponse()
        {
            // Arrange
            var hoteid = 1023;
            var arraivaldate = Convert.ToDateTime("2016-03-25");

            // Act
            var response = _hotelRatesController.Get(hoteid, arraivaldate);

            // Assert
            Assert.IsType<NotFoundResult>(response.Result);

        }

        [Fact]
        public void Get_WhenHotelRatesFound_ReturnsHotesRatesResponse()
        {
            // Arrange
            var hoteid = 7294;
            var arraivaldate = Convert.ToDateTime("2016-03-15");

            // Act
            var response = _hotelRatesController.Get(hoteid, arraivaldate).Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<HotelRateQuery>(response.Value);
            Assert.Equal(hoteid, items.hotel.hotelID);
            Assert.Equal(26, items.hotelRates.Count);// match total rates count
        }
    }
}
