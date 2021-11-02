using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VIMSAfrica.CORE.Dtos;
using VIMSAfrica.CORE.Model.Impl;
using VIMSAfrica.CORE.Service;

namespace VIMSAfrica.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SettingController : ControllerBase
    {
        private readonly ISettingService _settingService;
        private readonly ILogger<SettingController> _logger;

        public SettingController(ISettingService settingService ,ILogger<SettingController> logger)
        {
            _settingService = settingService;
            _logger = logger;
        }

        [HttpPost("addbrand")]
        public async Task<IActionResult> AddBrand(Brand brand)
        {
            if(brand == null) return BadRequest("Request can not be null");

            try
            {
                await _settingService.AddBrand(brand);

                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode(500, new { error = e.Message } );
            }
        }

        [HttpPost("removebrand")]
        public async Task<IActionResult> RemoveBrand(int brandId)
        {
            if(brandId <= 0) return BadRequest($"{brandId} is invalid");

            try
            {
                await _settingService.RemoveBrand(brandId);

                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode(500, new { error = e.Message } );
            }
        }


        [HttpPost("addmodel")]
        public async Task<IActionResult> AddModel(Model model)
        {
            if(model == null) return BadRequest("Request can not be null");

            try
            {
                await _settingService.AddModel(model);

                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode(500, new { error = e.Message } );
            }
        }

        [HttpPost("removemodel")]
        public async Task<IActionResult> RemoveModel(int modelId)
        {
            if(modelId <= 0) return BadRequest($"{modelId} is invalid");

            try
            {
                await _settingService.RemoveModel(modelId);

                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode(500, new { error = e.Message } );
            }
        }
    }
}
