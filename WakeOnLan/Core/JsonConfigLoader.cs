using System.IO;
using System.Text;
using Newtonsoft.Json;
using WakeOnLan.Model;

namespace WakeOnLan.Core
{
    public class JsonConfigLoader : IConfigLoader
    {
        private const string configPath = @"Config/devices.json";
        private DeviceList devices;

        private void LoadConfig()
        {
            string configFileContent = LoadConfigFileFromHardDrive();
            devices = BuildObjectFromString(configFileContent);
        }

        private string GetConfigAsString(DeviceList devices)
        {
            return JsonConvert.SerializeObject(devices);
        }

        private string LoadConfigFileFromHardDrive()
        {
            return File.ReadAllText(configPath, Encoding.UTF8);
        }

        private DeviceList BuildObjectFromString(string configAsString)
        {
            return JsonConvert.DeserializeObject<DeviceList>(configAsString);
        }

        public void UpdateAndReloadConfig(DeviceList devices)
        {
            WriteUpdatedConfigFile(devices);
            LoadConfig();
        }

        private void WriteUpdatedConfigFile(DeviceList updatedDevices)
        {
            string devicesAsJsonString = JsonConvert.SerializeObject(updatedDevices);
            File.WriteAllText(configPath, devicesAsJsonString, Encoding.UTF8);
        }

        public DeviceList GetConfig()
        {
            if (devices == null)
            {
                LoadConfig();
            }
            return devices;
        }
    }
}