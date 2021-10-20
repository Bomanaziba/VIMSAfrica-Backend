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
    public class AppSettingController : ControllerBase
    {

        private readonly ILogger<AppSettingController> _logger;

        private readonly IAppSettingService _appSettingService;

        public AppSettingController(IAppSettingService appSettingService ,ILogger<AppSettingController> logger)
        {
            _appSettingService = appSettingService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string key)
        {
            if(string.IsNullOrEmpty(key)) return BadRequest("key can not be null or empty");

            try
            {

                var result = await _appSettingService.GetAppSetting(key);

                return Ok(result);

            }catch(Exception e)
            {
                return StatusCode(500, new { error = e.Message } );
            }
        }

§       //NOT Tested
        [HttpPost]
        public async Task<IActionResult> Add(AddAppSettingDto addAppSettingDto)
        {
            if(addAppSettingDto == null) return BadRequest("Request can not be null");

            try
            {

                await _appSettingService.AddAppSetting(addAppSettingDto);

                return Ok();


            }catch(Exception e)
            {
                return StatusCode(500, new { error = e.Message } );
            }
        }
    }
}
