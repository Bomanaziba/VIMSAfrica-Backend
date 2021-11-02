using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VIMSAfrica.CORE.Dtos;
using VIMSAfrica.CORE.Service;

namespace VIMSAfrica.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DropDownController : ControllerBase
    {
        private readonly IDropDownService _dropDownService;
        private readonly ILogger<DropDownController> _logger;

        public DropDownController(IDropDownService dropDownService ,ILogger<DropDownController> logger)
        {
            _dropDownService = dropDownService;
            _logger = logger;
        }

        [HttpGet("brand")]
        public async Task<IActionResult> Brand()
        {
            try
            {
                var result = await _dropDownService.BrandDropDown();

                return Ok(result);
            }
            catch(Exception e)
            {
                return StatusCode(500, new { error = e.Message } );
            }
        }

        [HttpGet("model")]
        public async Task<IActionResult> Model(int brandId)
        {

            try
            {
                var result = await _dropDownService.ModelDropDown(brandId);

                return Ok(result);
            }
            catch(Exception e)
            {
                return StatusCode(500, new { error = e.Message } );
            }
        }

        [HttpGet("year")]
        public async Task<IActionResult> Year()
        {
            try
            {
                var result = await _dropDownService.YearDropDown();

                return Ok(result);
            }
            catch(Exception e)
            {
                return StatusCode(500, new { error = e.Message } );
            }
        }
    }
}
