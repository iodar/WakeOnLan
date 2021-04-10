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
        public IList<Device> Get()
        {
            IList<Device> deviceList = _configService.GetAllDevices();
            return deviceList;
        }

        [HttpGet("{id:int}")]
        public Device GetDeviceById(int id)
        {
            return _configService.GetDeviceById(id);
        }

        [HttpGet("{name}")]
        public Device GetDeviceByName(string name)
        {
            return _configService.GetDeviceByName(name);
        }
    }
}
