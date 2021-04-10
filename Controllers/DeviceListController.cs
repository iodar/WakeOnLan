using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WakeOnLan.Core.Service;
using WakeOnLan.Model;

namespace WakeOnLan.Controllers
{
    [ApiController]
    [Route("devicelist")]
    public class DeviceListController : ControllerBase
    {
        private readonly ILogger<DeviceListController> _logger;
        private readonly IConfigService _configService;

        public DeviceListController(ILogger<DeviceListController> logger)
        {
            _logger = logger;
            _configService = new ConfigService();
        }

        [HttpGet]
        public ActionResult<IList<Device>> Get()
        {
            IList<Device> deviceList = _configService.GetAllDevices();
            return new ActionResult<IList<Device>>(deviceList);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Device> GetDeviceById(int id)
        {
            try
            {
                Device device = _configService.GetDeviceById(id);
                if (device == null)
                {
                    return NotFound();
                }
                return device;
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("{name}")]
        public ActionResult<Device> GetDeviceByName(string name)
        {
            try
            {
                Device device = _configService.GetDeviceByName(name);

                if (device == null)
                {
                    return NotFound();
                }
                return device;
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }
    }
}
