using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Rsc.Api.ComModels;
using Nop.Plugin.Rsc.Api.Services;
using Nop.Services.Configuration;

namespace Nop.Plugin.Rsc.Api.Controllers
{
//    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController:Controller
    {
        private ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        [HttpPost]
        [Route("GetSetting")]
        public IActionResult GetProducts([FromBody] KeyValueModel keyValueModel)
        {
            return Ok(new KeyValueModel(){
                Key = keyValueModel.Key,
                Value = _settingService.GetSetting(keyValueModel.Key)?.Value
                    });
        }
    }
}