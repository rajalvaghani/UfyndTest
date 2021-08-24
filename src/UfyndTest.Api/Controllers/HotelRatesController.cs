using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UfyndTest.Api.Domain;
using UfyndTest.Api.Model;

namespace UfyndTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelRatesController : ControllerBase
    {

        public HotelRatesController()
        {
        }
        
        [HttpGet("{HotelID}/{ArrivalDate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<HotelRateQuery> Get(int HotelID, DateTime ArrivalDate)
        {
            try
            {
                var objhoterates = JsonConvert.DeserializeObject<List<HotelRateQuery>>(System.IO.File.ReadAllText(@"Content\hotelsrates.json"));
                var filteredhoterates = objhoterates.Where(x => x.hotel.hotelID == HotelID).ToList();
                if (filteredhoterates.Count > 0)
                {
                    var filterRates = filteredhoterates[0].hotelRates.Where(x => x.targetDay == ArrivalDate).ToList();
                    if (filterRates.Count == 0)
                        return NotFound();
                    return Ok(new HotelRateQuery(filteredhoterates[0].hotel, filterRates));
                }
                return NotFound();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
