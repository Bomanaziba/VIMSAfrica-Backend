using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using VIMSAfrica.CORE.Dtos;
using VIMSAfrica.CORE.Service;

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

        [HttpGet("get")]
        public async Task<IActionResult> Get(int index, int size, string searchParams)
        {
            try
            {
                var vehicleRecord = await _vehicleService.GetPagedVehicle(index, size, searchParams);

                return Ok(vehicleRecord);
            }
            catch (Exception e)
            {
                _logger.LogInformation("Exception for GetAllVehicles, {ex}", e.Message);

                return StatusCode(500, new { error = e.Message });
            }
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id<1) return BadRequest("Enter a valid Id");

            try
            {
                var vehicleRecord = await _vehicleService.GetVehicleById(id);

                return Ok(vehicleRecord);
            }
            catch (Exception e)
            {
                _logger.LogInformation("Exception for GetVehicle, {ex}", e.Message);
                return StatusCode(500, new { error = e.Message });
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(VehicleDto vehicleDto)
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

                return StatusCode(200, new { status = 200,  message = "Vehicle Added Successfully" });
            }
            catch (Exception e)
            {
                _logger.LogInformation("Exception for AddVehicle, {ex}", e.Message);
                return StatusCode(500, new { error = e.Message });
            }
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Edit(VehicleDto vehicleDto)
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


        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Request can not be null");

            try
            {
                await _vehicleService.RemoveVehicle(id);

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
