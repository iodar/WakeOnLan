using System.Collections.Generic;
using WakeOnLan.Model;
using System.Linq;

namespace WakeOnLan.Core.Service
{
    public class DeviceService : IDeviceService
    {

        private readonly IConfigLoader _configLoader;

        public DeviceService()
        {
            _configLoader = new JsonConfigLoader();
        }

        public IList<Device> GetAllDevices()
        {
            return GetConfig().Devices;
        }

        public Device GetDeviceById(int id)
        {
            return GetConfig().Devices.Where(device => device.Id == id).First();
        }

        public Device GetDeviceByName(string name)
        {
            return GetConfig().Devices.Where(device => device.Name == name).First();
        }

        private DeviceList GetConfig()
        {
            return _configLoader.GetConfig();
        }
    }
}