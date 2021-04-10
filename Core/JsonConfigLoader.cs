using System.IO;
using System.Text;
using Newtonsoft.Json;
using WakeOnLan.Model;

namespace WakeOnLan.Core
{
    public class JsonConfigLoader : IConfigLoader
    {
        private const string configPath = @"Config/devices.json";
        public DeviceList LoadConfig()
        {
            string configFileContent = LoadConfigFileFromHardDrive();
            return BuildObjectFromString(configFileContent);
        }

        public string GetConfigContent()
        {
            return GetConfigAsString(LoadConfig());
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
    }
}