using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WakeOnLan.Core.Service;
using WakeOnLan.Model;

namespace WakeOnLan.Controllers
{
    [ApiController]
    [Route("")]
    public class DeviceController : ControllerBase
    {
        private readonly ILogger<DeviceController> _logger;
        private readonly IDeviceService _configService;

        public DeviceController(ILogger<DeviceController> logger)
        {
            _logger = logger;
            _configService = new DeviceService();
        }

        [HttpGet("/devices")]
        public ActionResult<IList<Device>> Get()
        {
            IList<Device> deviceList = _configService.GetAllDevices();
            return new ActionResult<IList<Device>>(deviceList);
        }

        [HttpGet("/device/{id:int}")]
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

        [HttpGet("/device/{name}")]
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
