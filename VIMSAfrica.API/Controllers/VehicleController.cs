using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIMSAfrica.CORE.Dtos;
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
        public async Task<IActionResult> AddVehicle(VehicleDto vehicleDto)
        {
            if (vehicleDto == null) return BadRequest("Request can not be null");

            try
            {
                var vehicleRecord = await _vehicleService.GetVehicleByRegNumber(vehicleDto.RegistrationNumber);
                if (vehicleRecord!=null)
                {
                    return StatusCode(400, new { error = "Vehicle Already Exist" });

                }
                 await _vehicleService.AddVehicle(vehicleDto);

                return StatusCode(200, new { message = "Vehicle Added Successfully" });
            }
            catch (Exception e)
            {
                _logger.LogInformation("Exception for AddVehicle, {ex}", e.Message);
                return StatusCode(500, new { error = e.Message });
            }
        }

        // PUT api/<VehicleController>/5
        [HttpPut("update-vehicle/{id}")]
        public async Task<IActionResult> EditVehicle(VehicleDto vehicleDto)
        {
            if (vehicleDto == null) return BadRequest("Request can not be null");

            try
            {
                var vehicleRecord = await _vehicleService.GetVehicleById(vehicleDto.Id);
                if (vehicleRecord != null)
                {
                    return StatusCode(400, new { error = "Enter a valid Id" });

                }
                await _vehicleService.AddVehicle(vehicleDto);

                return StatusCode(200, new { message = "Vehicle Updated Successfully" });
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
            if (id<1) return BadRequest("Request can not be null");

            try
            {
                return StatusCode(200, new { message = "Vehicle Removed Successfully" });
            }
            catch (Exception e)
            {
                _logger.LogInformation("Exception for DeleteVehicle, {ex}", e.Message);
                return StatusCode(500, new { error = e.Message });
            }

        }
    }
}
