using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApi.Engines;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("gps_api/[controller]")]
    public class GetController : Controller
    {
        private readonly LatLongOption _gpsOptions;

        public GetController(IOptions<LatLongOption> optionAccessor)
        {
            _gpsOptions = optionAccessor.Value;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if(_gpsOptions.timestamp.Equals(
                    string.Empty))
                    return NoContent();
                    
                LatLongGps gps = null;

                // double d0 = double.Parse(_gpsOptions.timestamp);
                double d0;
                if(id == 0)
                    d0 = double.Parse(_gpsOptions.timestamp);
                else
                    d0 = double.Parse(_gpsOptions.timestamp_rover);

                double d1 = System.DateTime.Now.GetUnixEpoch();
                double diff = 10.0; // number of seconds different maximum
                if((d1 - d0) < diff)
                {
                    if(id == 0)
                        gps = new LatLongGps()
                        {
                            latitude = _gpsOptions.latitude,
                            longitude = _gpsOptions.longitude
                        };
                    else
                        gps = new LatLongGps()
                        {
                            latitude = _gpsOptions.latitude_rover,
                            longitude = _gpsOptions.longitude_rover
                        };
                };

                return Content(
                    JsonConvert.SerializeObject(
                        gps));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}