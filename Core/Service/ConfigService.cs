using System.Collections.Generic;
using WakeOnLan.Model;
using System.Linq;

namespace WakeOnLan.Core.Service
{
    public class ConfigService : IConfigService
    {

        private readonly IConfigLoader _configLoader;

        public ConfigService()
        {
            _configLoader = new JsonConfigLoader();
        }

        public IList<Device> GetAllDevices()
        {
            return LoadConfig().Devices;
        }

        public Device GetDeviceById(int id)
        {
            return LoadConfig().Devices.Where(device => device.Id == id).First();
        }

        public Device GetDeviceByName(string name)
        {
            return LoadConfig().Devices.Where(device => device.Name == name).First();
        }

        private DeviceList LoadConfig()
        {
            return _configLoader.LoadConfig();
        }
    }
}