using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApi.Engines;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("gps_api/[controller]")]
    public class PostController : Controller
    {
        private readonly LatLongOption _gpsOptions;

        public PostController(
            IOptions<LatLongOption> optionAccessor)
        {
            _gpsOptions = optionAccessor.Value;
        }

        // // POST api/values
        // [HttpPost]
        // public IActionResult Post(
        //     [FromBody]LatLongGps gpsData)
        // {
        //     try
        //     {
        //         double d = DateTime.Now.GetUnixEpoch();
        //         _gpsOptions.timestamp = d.ToString();
        //         _gpsOptions.latitude = gpsData.latitude;
        //         _gpsOptions.longitude = gpsData.longitude;

        //         return Ok();
        //     }
        //     catch
        //     {
        //         return BadRequest();
        //     }
        // }

        // POST api/values
        [HttpPost("{id}")]
        public IActionResult Post(
            int id,
            [FromBody]LatLongGps gpsData)
        {
            try
            {
                double d = DateTime.Now.GetUnixEpoch();
                if(id == 1)
                {
                    _gpsOptions.timestamp_rover = d.ToString();
                    _gpsOptions.latitude_rover = gpsData.latitude;
                    _gpsOptions.longitude_rover = gpsData.longitude;
                }
                else
                {
                    _gpsOptions.timestamp = d.ToString();
                    _gpsOptions.latitude = gpsData.latitude;
                    _gpsOptions.longitude = gpsData.longitude;
                }

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}