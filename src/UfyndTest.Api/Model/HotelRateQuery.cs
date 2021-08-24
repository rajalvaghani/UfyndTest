using System;
using System.Collections.Generic;
using UfyndTest.Api.Domain;

namespace UfyndTest.Api.Model
{
    public class HotelRateQuery
    {
        public HotelRateQuery(Hotel hoteldetail, List<HotelRate> hotelRatesdetails)
        {
            hotel = hoteldetail;
            hotelRates = hotelRatesdetails;
        }
        public Hotel hotel { get; set; }
        public List<HotelRate> hotelRates { get; set; }

    }
}
