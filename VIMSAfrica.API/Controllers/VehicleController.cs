using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIMSAfrica.CORE.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VIMSAfrica.API.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class VehicleController : ControllerBase
    {


        private readonly ILogger<VehicleController> _logger;

        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService, ILogger<VehicleController> logger)
        {
            _vehicleService = vehicleService;
            _logger = logger;
        }
        // GET: api/<VehicleController>
        [HttpGet("get-all-vehicles")]
        public async Task<IActionResult> GetAllVehicles()
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogInformation("Exception for GetAllVehicles, {ex}", e.Message);

                return StatusCode(500, new { error = e.Message });
            }
        }

        // GET api/<VehicleController>/5
        [HttpGet("get-vehicle/{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogInformation("Exception for GetVehicle, {ex}", e.Message);
                return StatusCode(500, new { error = e.Message });
            }
        }

        // POST api/<VehicleController>
        [HttpPost("add-vehicle")]
        public async Task<IActionResult> AddVehicle([FromBody] string value)
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogInformation("Exception for AddVehicle, {ex}", e.Message);
                return StatusCode(500, new { error = e.Message });
            }
        }

        // PUT api/<VehicleController>/5
        [HttpPut("update-vehicle/{id}")]
        public async Task<IActionResult> EditVehicle(int id, [FromBody] string value)
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogInformation("Exception for editVehicle, {ex}",  e.Message);

                return StatusCode(500, new { error = e.Message });
            }
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("delete-vehicle/{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogInformation("Exception for DeleteVehicle, {ex}", e.Message);
                return StatusCode(500, new { error = e.Message });
            }

        }
    }
}
